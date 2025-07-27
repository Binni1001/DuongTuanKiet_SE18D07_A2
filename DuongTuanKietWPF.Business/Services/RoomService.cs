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
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RoomDto>> GetAllRoomsAsync()
        {
            var rooms = await _unitOfWork.Rooms.GetRoomsWithTypeAsync();
            return MappingHelper.ToDto(rooms);
        }

        public async Task<RoomDto?> GetRoomByIdAsync(int roomId)
        {
            var room = await _unitOfWork.Rooms.GetRoomWithTypeByIdAsync(roomId);
            return room != null ? MappingHelper.ToDto(room) : null;
        }

        public async Task<RoomDto> CreateRoomAsync(RoomCreateDto roomCreateDto)
        {
            // Check if room number already exists
            if (await _unitOfWork.Rooms.IsRoomNumberExistsAsync(roomCreateDto.RoomNumber))
            {
                throw new InvalidOperationException("Room number already exists.");
            }

            // Validate room type exists
            var roomType = await _unitOfWork.RoomTypes.GetByIdAsync(roomCreateDto.RoomTypeId);
            if (roomType == null)
            {
                throw new InvalidOperationException("Room type not found.");
            }

            var room = MappingHelper.ToEntity(roomCreateDto);
            await _unitOfWork.Rooms.AddAsync(room);
            await _unitOfWork.SaveChangesAsync();

            return MappingHelper.ToDto(room);
        }

        public async Task<RoomDto> UpdateRoomAsync(RoomUpdateDto roomUpdateDto)
        {
            var existingRoom = await _unitOfWork.Rooms.GetByIdAsync(roomUpdateDto.RoomId);
            if (existingRoom == null)
            {
                throw new InvalidOperationException("Room not found.");
            }

            // Check if room number already exists (excluding current room)
            if (await _unitOfWork.Rooms.IsRoomNumberExistsAsync(roomUpdateDto.RoomNumber, roomUpdateDto.RoomId))
            {
                throw new InvalidOperationException("Room number already exists.");
            }

            // Validate room type exists
            var roomType = await _unitOfWork.RoomTypes.GetByIdAsync(roomUpdateDto.RoomTypeId);
            if (roomType == null)
            {
                throw new InvalidOperationException("Room type not found.");
            }

            MappingHelper.UpdateEntity(existingRoom, roomUpdateDto);
            _unitOfWork.Rooms.Update(existingRoom);
            await _unitOfWork.SaveChangesAsync();

            return MappingHelper.ToDto(existingRoom);
        }

        public async Task<bool> DeleteRoomAsync(int roomId)
        {
            var room = await _unitOfWork.Rooms.GetByIdAsync(roomId);
            if (room == null)
            {
                return false;
            }

            // Check if room can be deleted (not in any booking)
            if (!await _unitOfWork.Rooms.CanDeleteRoomAsync(roomId))
            {
                // Don't delete, just deactivate
                room.RoomStatus = 0;
                _unitOfWork.Rooms.Update(room);
            }
            else
            {
                _unitOfWork.Rooms.Delete(room);
            }

            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RoomDto>> SearchRoomsAsync(string searchTerm)
        {
            var rooms = await _unitOfWork.Rooms.FindAsync(r => 
                r.RoomNumber.Contains(searchTerm) || 
                (r.RoomDetailDescription != null && r.RoomDetailDescription.Contains(searchTerm)) ||
                (r.RoomType != null && r.RoomType.RoomTypeName.Contains(searchTerm)));
            
            return MappingHelper.ToDto(rooms);
        }

        public async Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync()
        {
            var rooms = await _unitOfWork.Rooms.GetAvailableRoomsAsync();
            return MappingHelper.ToDto(rooms);
        }

        public async Task<bool> IsRoomNumberExistsAsync(string roomNumber, int? excludeRoomId = null)
        {
            return await _unitOfWork.Rooms.IsRoomNumberExistsAsync(roomNumber, excludeRoomId);
        }

        public async Task<IEnumerable<RoomTypeDto>> GetAllRoomTypesAsync()
        {
            var roomTypes = await _unitOfWork.RoomTypes.GetAllAsync();
            return MappingHelper.ToDto(roomTypes);
        }

        public async Task<RoomTypeDto?> GetRoomTypeByIdAsync(int roomTypeId)
        {
            var roomType = await _unitOfWork.RoomTypes.GetByIdAsync(roomTypeId);
            return roomType != null ? MappingHelper.ToDto(roomType) : null;
        }
    }
}
