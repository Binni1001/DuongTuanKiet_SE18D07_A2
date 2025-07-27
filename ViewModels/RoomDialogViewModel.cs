using DuongTuanKietWPF.Business.DTOs;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DuongTuanKiet_SE18D07_A02.ViewModels
{
    public class RoomDialogViewModel : BaseViewModel
    {
        private int _roomId;
        private string _roomNumber = string.Empty;
        private string? _roomDetailDescription;
        private int? _roomMaxCapacity;
        private int _roomTypeId;
        private byte _roomStatus = 1;
        private decimal? _roomPricePerDay;
        private string _validationErrors = string.Empty;
        private bool _isNewRoom;
        private ObservableCollection<RoomTypeDto> _roomTypes = new();
        private RoomTypeDto? _selectedRoomType;

        public RoomDialogViewModel(ObservableCollection<RoomTypeDto> roomTypes, RoomDto? room = null)
        {
            RoomTypes = roomTypes;
            IsNewRoom = room == null;
            
            if (room != null)
            {
                RoomId = room.RoomId;
                RoomNumber = room.RoomNumber;
                RoomDetailDescription = room.RoomDetailDescription;
                RoomMaxCapacity = room.RoomMaxCapacity;
                RoomTypeId = room.RoomTypeId;
                RoomStatus = room.RoomStatus;
                RoomPricePerDay = room.RoomPricePerDay;
                SelectedRoomType = RoomTypes.FirstOrDefault(rt => rt.RoomTypeId == room.RoomTypeId);
            }
            else if (RoomTypes.Any())
            {
                SelectedRoomType = RoomTypes.First();
                RoomTypeId = SelectedRoomType.RoomTypeId;
            }
        }

        public string Title => IsNewRoom ? "Add New Room" : "Edit Room";

        public int RoomId
        {
            get => _roomId;
            set => SetProperty(ref _roomId, value);
        }

        public string RoomNumber
        {
            get => _roomNumber;
            set => SetProperty(ref _roomNumber, value);
        }

        public string? RoomDetailDescription
        {
            get => _roomDetailDescription;
            set => SetProperty(ref _roomDetailDescription, value);
        }

        public int? RoomMaxCapacity
        {
            get => _roomMaxCapacity;
            set => SetProperty(ref _roomMaxCapacity, value);
        }

        public int RoomTypeId
        {
            get => _roomTypeId;
            set => SetProperty(ref _roomTypeId, value);
        }

        public byte RoomStatus
        {
            get => _roomStatus;
            set => SetProperty(ref _roomStatus, value);
        }

        public decimal? RoomPricePerDay
        {
            get => _roomPricePerDay;
            set => SetProperty(ref _roomPricePerDay, value);
        }

        public string ValidationErrors
        {
            get => _validationErrors;
            set => SetProperty(ref _validationErrors, value);
        }

        public bool IsNewRoom
        {
            get => _isNewRoom;
            set => SetProperty(ref _isNewRoom, value);
        }

        public ObservableCollection<RoomTypeDto> RoomTypes
        {
            get => _roomTypes;
            set => SetProperty(ref _roomTypes, value);
        }

        public RoomTypeDto? SelectedRoomType
        {
            get => _selectedRoomType;
            set 
            { 
                SetProperty(ref _selectedRoomType, value);
                if (value != null)
                {
                    RoomTypeId = value.RoomTypeId;
                }
            }
        }

        public bool ValidateInput()
        {
            var errors = new StringBuilder();

            // Validate Room Number
            if (string.IsNullOrWhiteSpace(RoomNumber))
                errors.AppendLine("Room number is required.");
            else if (RoomNumber.Length > 50)
                errors.AppendLine("Room number cannot exceed 50 characters.");

            // Validate Description
            if (!string.IsNullOrWhiteSpace(RoomDetailDescription) && RoomDetailDescription.Length > 220)
                errors.AppendLine("Room description cannot exceed 220 characters.");

            // Validate Capacity
            if (RoomMaxCapacity.HasValue && (RoomMaxCapacity < 1 || RoomMaxCapacity > 10))
                errors.AppendLine("Room capacity must be between 1 and 10.");

            // Validate Room Type
            if (RoomTypeId <= 0)
                errors.AppendLine("Please select a room type.");

            // Validate Price
            if (RoomPricePerDay.HasValue && RoomPricePerDay <= 0)
                errors.AppendLine("Room price must be greater than 0.");

            ValidationErrors = errors.ToString().Trim();
            return string.IsNullOrEmpty(ValidationErrors);
        }

        public RoomDto ToRoomDto()
        {
            return new RoomDto
            {
                RoomId = RoomId,
                RoomNumber = RoomNumber,
                RoomDetailDescription = RoomDetailDescription,
                RoomMaxCapacity = RoomMaxCapacity,
                RoomTypeId = RoomTypeId,
                RoomStatus = RoomStatus,
                RoomPricePerDay = RoomPricePerDay,
                RoomTypeName = SelectedRoomType?.RoomTypeName,
                TypeDescription = SelectedRoomType?.TypeDescription
            };
        }
    }
}
