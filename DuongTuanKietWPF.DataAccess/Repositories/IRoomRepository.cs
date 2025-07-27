using DuongTuanKietWPF.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DuongTuanKietWPF.DataAccess.Repositories
{
    public interface IRoomRepository : IGenericRepository<RoomInformation>
    {
        Task<IEnumerable<RoomInformation>> GetRoomsWithTypeAsync();
        Task<RoomInformation?> GetRoomWithTypeByIdAsync(int roomId);
        Task<bool> IsRoomNumberExistsAsync(string roomNumber, int? excludeRoomId = null);
        Task<bool> CanDeleteRoomAsync(int roomId);
        Task<IEnumerable<RoomInformation>> GetAvailableRoomsAsync();
    }
}
