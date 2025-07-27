using DuongTuanKietWPF.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuongTuanKietWPF.DataAccess.Repositories
{
    public class RoomRepository : GenericRepository<RoomInformation>, IRoomRepository
    {
        public RoomRepository(FUMiniHotelManagementContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RoomInformation>> GetRoomsWithTypeAsync()
        {
            return await _dbSet.Include(r => r.RoomType).ToListAsync();
        }

        public async Task<RoomInformation?> GetRoomWithTypeByIdAsync(int roomId)
        {
            return await _dbSet.Include(r => r.RoomType)
                              .FirstOrDefaultAsync(r => r.RoomId == roomId);
        }

        public async Task<bool> IsRoomNumberExistsAsync(string roomNumber, int? excludeRoomId = null)
        {
            if (excludeRoomId.HasValue)
            {
                return await _dbSet.AnyAsync(r => r.RoomNumber == roomNumber && r.RoomId != excludeRoomId.Value);
            }
            return await _dbSet.AnyAsync(r => r.RoomNumber == roomNumber);
        }

        public async Task<bool> CanDeleteRoomAsync(int roomId)
        {
            return !await _context.BookingDetails.AnyAsync(bd => bd.RoomId == roomId);
        }

        public async Task<IEnumerable<RoomInformation>> GetAvailableRoomsAsync()
        {
            return await _dbSet.Include(r => r.RoomType)
                              .Where(r => r.RoomStatus == 1)
                              .ToListAsync();
        }
    }
}
