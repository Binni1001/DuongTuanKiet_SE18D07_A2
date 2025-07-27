using DuongTuanKietWPF.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuongTuanKietWPF.DataAccess.Repositories
{
    public class BookingDetailRepository : GenericRepository<BookingDetail>, IBookingDetailRepository
    {
        public BookingDetailRepository(FUMiniHotelManagementContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BookingDetail>> GetBookingDetailsByBookingIdAsync(int bookingReservationId)
        {
            return await _dbSet
                .Include(bd => bd.Room)
                    .ThenInclude(r => r.RoomType)
                .Where(bd => bd.BookingReservationId == bookingReservationId)
                .ToListAsync();
        }

        public async Task DeleteByBookingIdAsync(int bookingReservationId)
        {
            var details = await _dbSet
                .Where(bd => bd.BookingReservationId == bookingReservationId)
                .ToListAsync();
            
            if (details.Any())
            {
                _dbSet.RemoveRange(details);
            }
        }
    }
}
