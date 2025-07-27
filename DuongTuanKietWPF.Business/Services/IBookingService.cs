using DuongTuanKietWPF.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DuongTuanKietWPF.Business.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
        Task<BookingDto?> GetBookingByIdAsync(int bookingId);
        Task<BookingDto> CreateBookingAsync(BookingCreateDto bookingCreateDto);
        Task<BookingDto> UpdateBookingAsync(BookingUpdateDto bookingUpdateDto);
        Task<bool> DeleteBookingAsync(int bookingId);
        Task<IEnumerable<BookingDto>> GetBookingsByCustomerAsync(int customerId);
        Task<IEnumerable<BookingDto>> SearchBookingsAsync(string searchTerm);
        Task<IEnumerable<BookingReportDto>> GetBookingsReportAsync(DateOnly startDate, DateOnly endDate);
        Task<decimal> CalculateTotalPriceAsync(List<BookingDetailCreateDto> bookingDetails);
        Task<bool> ValidateBookingDatesAsync(List<BookingDetailCreateDto> bookingDetails);
    }
}
