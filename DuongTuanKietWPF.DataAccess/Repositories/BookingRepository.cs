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
            return await _dbSet
                .Include(b => b.Customer)
                .Include(b => b.BookingDetails)
                    .ThenInclude(bd => bd.Room)
                        .ThenInclude(r => r.RoomType)
                .ToListAsync();
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
