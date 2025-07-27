using DuongTuanKietWPF.Business.DTOs;
using DuongTuanKietWPF.Business.Helpers;
using DuongTuanKietWPF.DataAccess.Models;
using DuongTuanKietWPF.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuongTuanKietWPF.Business.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync()
        {
            var bookings = await _unitOfWork.Bookings.GetBookingsWithDetailsAsync();
            return MappingHelper.ToDto(bookings);
        }

        public async Task<BookingDto?> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _unitOfWork.Bookings.GetBookingWithDetailsAsync(bookingId);
            return booking != null ? MappingHelper.ToDto(booking) : null;
        }

        public async Task<BookingDto> CreateBookingAsync(BookingCreateDto bookingCreateDto)
        {
            // Validate customer exists
            var customer = await _unitOfWork.Customers.GetByIdAsync(bookingCreateDto.CustomerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            // Validate booking dates
            if (!await ValidateBookingDatesAsync(bookingCreateDto.BookingDetails))
            {
                throw new InvalidOperationException("Invalid booking dates. End date must be after start date.");
            }

            // Calculate total price
            var totalPrice = await CalculateTotalPriceAsync(bookingCreateDto.BookingDetails);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var booking = MappingHelper.ToEntity(bookingCreateDto);
                booking.TotalPrice = totalPrice;

                await _unitOfWork.Bookings.AddAsync(booking);
                await _unitOfWork.SaveChangesAsync();

                // Add booking details
                foreach (var detailDto in bookingCreateDto.BookingDetails)
                {
                    var detail = MappingHelper.ToEntity(detailDto);
                    detail.BookingReservationId = booking.BookingReservationId;
                    await _unitOfWork.BookingDetails.AddAsync(detail);
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                return MappingHelper.ToDto(booking);
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<BookingDto> UpdateBookingAsync(BookingUpdateDto bookingUpdateDto)
        {
            var existingBooking = await _unitOfWork.Bookings.GetBookingWithDetailsAsync(bookingUpdateDto.BookingReservationId);
            if (existingBooking == null)
            {
                throw new InvalidOperationException("Booking not found.");
            }

            // Validate customer exists
            var customer = await _unitOfWork.Customers.GetByIdAsync(bookingUpdateDto.CustomerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            // Validate booking dates
            if (!await ValidateBookingDatesAsync(bookingUpdateDto.BookingDetails))
            {
                throw new InvalidOperationException("Invalid booking dates. End date must be after start date.");
            }

            // Calculate total price
            var totalPrice = await CalculateTotalPriceAsync(bookingUpdateDto.BookingDetails);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                // Update booking
                MappingHelper.UpdateEntity(existingBooking, bookingUpdateDto);
                existingBooking.TotalPrice = totalPrice;
                _unitOfWork.Bookings.Update(existingBooking);

                // Delete existing booking details
                await _unitOfWork.BookingDetails.DeleteByBookingIdAsync(existingBooking.BookingReservationId);

                // Add new booking details
                foreach (var detailDto in bookingUpdateDto.BookingDetails)
                {
                    var detail = MappingHelper.ToEntity(detailDto);
                    detail.BookingReservationId = existingBooking.BookingReservationId;
                    await _unitOfWork.BookingDetails.AddAsync(detail);
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                return MappingHelper.ToDto(existingBooking);
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<bool> DeleteBookingAsync(int bookingId)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(bookingId);
            if (booking == null)
            {
                return false;
            }

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                // Delete booking details first
                await _unitOfWork.BookingDetails.DeleteByBookingIdAsync(bookingId);
                
                // Delete booking
                _unitOfWork.Bookings.Delete(booking);
                
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
                return true;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsByCustomerAsync(int customerId)
        {
            var bookings = await _unitOfWork.Bookings.GetBookingsByCustomerAsync(customerId);
            return MappingHelper.ToDto(bookings);
        }

        public async Task<IEnumerable<BookingDto>> SearchBookingsAsync(string searchTerm)
        {
            var bookings = await _unitOfWork.Bookings.FindAsync(b =>
                (b.Customer != null && b.Customer.CustomerFullName.Contains(searchTerm)) ||
                (b.Customer != null && b.Customer.EmailAddress.Contains(searchTerm)) ||
                b.BookingReservationId.ToString().Contains(searchTerm));

            return MappingHelper.ToDto(bookings);
        }

        public async Task<IEnumerable<BookingReportDto>> GetBookingsReportAsync(DateOnly startDate, DateOnly endDate)
        {
            var bookings = await _unitOfWork.Bookings.GetBookingsForReportAsync(startDate, endDate);
            return MappingHelper.ToReportDto(bookings);
        }

        public async Task<decimal> CalculateTotalPriceAsync(List<BookingDetailCreateDto> bookingDetails)
        {
            decimal totalPrice = 0;

            foreach (var detail in bookingDetails)
            {
                if (detail.ActualPrice.HasValue)
                {
                    var days = detail.EndDate.DayNumber - detail.StartDate.DayNumber;
                    totalPrice += detail.ActualPrice.Value * days;
                }
                else
                {
                    // Get room price if actual price not provided
                    var room = await _unitOfWork.Rooms.GetByIdAsync(detail.RoomId);
                    if (room?.RoomPricePerDay.HasValue == true)
                    {
                        var days = detail.EndDate.DayNumber - detail.StartDate.DayNumber;
                        totalPrice += room.RoomPricePerDay.Value * days;
                    }
                }
            }

            return totalPrice;
        }

        public async Task<bool> ValidateBookingDatesAsync(List<BookingDetailCreateDto> bookingDetails)
        {
            foreach (var detail in bookingDetails)
            {
                if (detail.EndDate <= detail.StartDate)
                {
                    return false;
                }

                // Validate room exists
                var room = await _unitOfWork.Rooms.GetByIdAsync(detail.RoomId);
                if (room == null || room.RoomStatus != 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
