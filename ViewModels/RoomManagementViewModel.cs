using DuongTuanKiet_SE18D07_A02.Commands;
using DuongTuanKietWPF.Business.DTOs;
using DuongTuanKietWPF.Business.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DuongTuanKiet_SE18D07_A02.ViewModels
{
    public class RoomManagementViewModel : BaseViewModel
    {
        private readonly IRoomService _roomService;
        private ObservableCollection<RoomDto> _rooms = new();
        private ObservableCollection<RoomTypeDto> _roomTypes = new();
        private RoomDto? _selectedRoom;
        private string _searchText = string.Empty;
        private bool _isLoading;

        public RoomManagementViewModel()
        {
            _roomService = ServiceFactory.GetRoomService();
            
            AddCommand = new RelayCommand(async () => await AddRoomAsync());
            EditCommand = new RelayCommand(async () => await EditRoomAsync(), () => SelectedRoom != null);
            DeleteCommand = new RelayCommand(async () => await DeleteRoomAsync(), () => SelectedRoom != null);
            SearchCommand = new RelayCommand(async () => await SearchRoomsAsync());
            RefreshCommand = new RelayCommand(async () => await LoadRoomsAsync());

            _ = LoadDataAsync();
        }

        public ObservableCollection<RoomDto> Rooms
        {
            get => _rooms;
            set => SetProperty(ref _rooms, value);
        }

        public ObservableCollection<RoomTypeDto> RoomTypes
        {
            get => _roomTypes;
            set => SetProperty(ref _roomTypes, value);
        }

        public RoomDto? SelectedRoom
        {
            get => _selectedRoom;
            set => SetProperty(ref _selectedRoom, value);
        }

        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand RefreshCommand { get; }

        private async Task LoadDataAsync()
        {
            await LoadRoomsAsync();
            await LoadRoomTypesAsync();
        }

        private async Task LoadRoomsAsync()
        {
            try
            {
                IsLoading = true;
                var rooms = await _roomService.GetAllRoomsAsync();
                Rooms.Clear();
                foreach (var room in rooms)
                {
                    Rooms.Add(room);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task LoadRoomTypesAsync()
        {
            try
            {
                var roomTypes = await _roomService.GetAllRoomTypesAsync();
                RoomTypes.Clear();
                foreach (var roomType in roomTypes)
                {
                    RoomTypes.Add(roomType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room types: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task AddRoomAsync()
        {
            var dialog = new Views.RoomDialog(RoomTypes);
            if (dialog.ShowDialog() == true && dialog.Room != null)
            {
                try
                {
                    IsLoading = true;
                    var createDto = new RoomCreateDto
                    {
                        RoomNumber = dialog.Room.RoomNumber,
                        RoomDetailDescription = dialog.Room.RoomDetailDescription,
                        RoomMaxCapacity = dialog.Room.RoomMaxCapacity,
                        RoomTypeId = dialog.Room.RoomTypeId,
                        RoomPricePerDay = dialog.Room.RoomPricePerDay
                    };

                    var newRoom = await _roomService.CreateRoomAsync(createDto);
                    Rooms.Add(newRoom);
                    MessageBox.Show("Room added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding room: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        private async Task EditRoomAsync()
        {
            if (SelectedRoom == null) return;

            var dialog = new Views.RoomDialog(RoomTypes, SelectedRoom);
            if (dialog.ShowDialog() == true && dialog.Room != null)
            {
                try
                {
                    IsLoading = true;
                    var updateDto = new RoomUpdateDto
                    {
                        RoomId = dialog.Room.RoomId,
                        RoomNumber = dialog.Room.RoomNumber,
                        RoomDetailDescription = dialog.Room.RoomDetailDescription,
                        RoomMaxCapacity = dialog.Room.RoomMaxCapacity,
                        RoomTypeId = dialog.Room.RoomTypeId,
                        RoomStatus = dialog.Room.RoomStatus,
                        RoomPricePerDay = dialog.Room.RoomPricePerDay
                    };

                    var updatedRoom = await _roomService.UpdateRoomAsync(updateDto);
                    var index = Rooms.ToList().FindIndex(r => r.RoomId == updatedRoom.RoomId);
                    if (index >= 0)
                    {
                        Rooms[index] = updatedRoom;
                    }
                    MessageBox.Show("Room updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating room: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        private async Task DeleteRoomAsync()
        {
            if (SelectedRoom == null) return;

            var result = MessageBox.Show($"Are you sure you want to delete room '{SelectedRoom.RoomNumber}'?\n\nNote: If this room has booking history, it will be deactivated instead of deleted.", 
                "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    IsLoading = true;
                    var success = await _roomService.DeleteRoomAsync(SelectedRoom.RoomId);
                    if (success)
                    {
                        await LoadRoomsAsync(); // Reload to reflect changes
                        SelectedRoom = null;
                        MessageBox.Show("Room deleted/deactivated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting room: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        private async Task SearchRoomsAsync()
        {
            try
            {
                IsLoading = true;
                if (string.IsNullOrWhiteSpace(SearchText))
                {
                    await LoadRoomsAsync();
                }
                else
                {
                    var rooms = await _roomService.SearchRoomsAsync(SearchText);
                    Rooms.Clear();
                    foreach (var room in rooms)
                    {
                        Rooms.Add(room);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching rooms: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
