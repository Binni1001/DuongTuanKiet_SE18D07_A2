using DuongTuanKietWPF.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuongTuanKietWPF.DataAccess.Repositories
{
    public class BookingRepository : GenericRepository<BookingReservation>, IBookingRepository
    {
        public BookingRepository(FUMiniHotelManagementContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BookingReservation>> GetBookingsWithDetailsAsync()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("BookingRepository: Getting bookings with details...");

                // First test basic connection
                var count = await _dbSet.CountAsync();
                System.Diagnostics.Debug.WriteLine($"BookingRepository: Total booking count in database: {count}");

                // Test basic query without includes
                var basicBookings = await _dbSet.ToListAsync();
                System.Diagnostics.Debug.WriteLine($"BookingRepository: Basic bookings retrieved: {basicBookings.Count}");

                // Now try with includes
                var bookings = await _dbSet
                    .Include(b => b.Customer)
                    .Include(b => b.BookingDetails)
                        .ThenInclude(bd => bd.Room)
                            .ThenInclude(r => r.RoomType)
                    .ToListAsync();

                System.Diagnostics.Debug.WriteLine($"BookingRepository: Found {bookings.Count()} bookings with details");

                foreach (var booking in bookings)
                {
                    System.Diagnostics.Debug.WriteLine($"BookingRepository: Booking {booking.BookingReservationId}, Customer: {booking.Customer?.CustomerFullName}, Details: {booking.BookingDetails?.Count ?? 0}");
                }

                return bookings;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"BookingRepository: Error getting bookings - {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"BookingRepository: Stack trace - {ex.StackTrace}");
                throw;
            }
        }

        public async Task<BookingReservation?> GetBookingWithDetailsAsync(int bookingId)
        {
            return await _dbSet
                .Include(b => b.Customer)
                .Include(b => b.BookingDetails)
                    .ThenInclude(bd => bd.Room)
                        .ThenInclude(r => r.RoomType)
                .FirstOrDefaultAsync(b => b.BookingReservationId == bookingId);
        }

        public async Task<IEnumerable<BookingReservation>> GetBookingsByCustomerAsync(int customerId)
        {
            return await _dbSet
                .Include(b => b.BookingDetails)
                    .ThenInclude(bd => bd.Room)
                        .ThenInclude(r => r.RoomType)
                .Where(b => b.CustomerId == customerId)
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<BookingReservation>> GetBookingsByDateRangeAsync(DateOnly startDate, DateOnly endDate)
        {
            return await _dbSet
                .Include(b => b.Customer)
                .Include(b => b.BookingDetails)
                    .ThenInclude(bd => bd.Room)
                .Where(b => b.BookingDate >= startDate && b.BookingDate <= endDate)
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<BookingReservation>> GetBookingsForReportAsync(DateOnly startDate, DateOnly endDate)
        {
            return await _dbSet
                .Include(b => b.Customer)
                .Include(b => b.BookingDetails)
                    .ThenInclude(bd => bd.Room)
                        .ThenInclude(r => r.RoomType)
                .Where(b => b.BookingDate >= startDate && b.BookingDate <= endDate && b.BookingStatus == 1)
                .OrderByDescending(b => b.TotalPrice)
                .ToListAsync();
        }
    }
}
