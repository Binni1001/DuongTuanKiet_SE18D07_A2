using DuongTuanKietWPF.Business.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DuongTuanKietWPF.Business.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllRoomsAsync();
        Task<RoomDto?> GetRoomByIdAsync(int roomId);
        Task<RoomDto> CreateRoomAsync(RoomCreateDto roomCreateDto);
        Task<RoomDto> UpdateRoomAsync(RoomUpdateDto roomUpdateDto);
        Task<bool> DeleteRoomAsync(int roomId);
        Task<IEnumerable<RoomDto>> SearchRoomsAsync(string searchTerm);
        Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync();
        Task<bool> IsRoomNumberExistsAsync(string roomNumber, int? excludeRoomId = null);
        Task<IEnumerable<RoomTypeDto>> GetAllRoomTypesAsync();
        Task<RoomTypeDto?> GetRoomTypeByIdAsync(int roomTypeId);
    }
}
