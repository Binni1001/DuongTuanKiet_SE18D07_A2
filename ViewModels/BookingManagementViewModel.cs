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
    public class BookingManagementViewModel : BaseViewModel
    {
        private readonly IBookingService _bookingService;
        private readonly ICustomerService _customerService;
        private readonly IRoomService _roomService;
        private readonly CustomerDto _currentUser;
        private ObservableCollection<BookingDto> _bookings = new();
        private ObservableCollection<CustomerDto> _customers = new();
        private ObservableCollection<RoomDto> _rooms = new();
        private BookingDto? _selectedBooking;
        private string _searchText = string.Empty;
        private bool _isLoading;

        public BookingManagementViewModel(CustomerDto currentUser)
        {
            _currentUser = currentUser;
            _bookingService = ServiceFactory.GetBookingService();
            _customerService = ServiceFactory.GetCustomerService();
            _roomService = ServiceFactory.GetRoomService();
            
            AddCommand = new RelayCommand(async () => await AddBookingAsync(), () => IsAdmin);
            EditCommand = new RelayCommand(async () => await EditBookingAsync(), () => SelectedBooking != null && IsAdmin);
            DeleteCommand = new RelayCommand(async () => await DeleteBookingAsync(), () => SelectedBooking != null && IsAdmin);
            SearchCommand = new RelayCommand(async () => await SearchBookingsAsync());
            RefreshCommand = new RelayCommand(async () => await LoadBookingsAsync());
            ViewDetailsCommand = new RelayCommand(async () => await ViewBookingDetailsAsync(), () => SelectedBooking != null);

            _ = LoadDataAsync();
        }

        public ObservableCollection<BookingDto> Bookings
        {
            get => _bookings;
            set => SetProperty(ref _bookings, value);
        }

        public ObservableCollection<CustomerDto> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }

        public ObservableCollection<RoomDto> Rooms
        {
            get => _rooms;
            set => SetProperty(ref _rooms, value);
        }

        public BookingDto? SelectedBooking
        {
            get => _selectedBooking;
            set => SetProperty(ref _selectedBooking, value);
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

        public bool IsAdmin => _currentUser.CustomerId == 0 || _currentUser.EmailAddress == "admin@FUMiniHotelSystem.com";

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand ViewDetailsCommand { get; }

        private async Task LoadDataAsync()
        {
            await LoadBookingsAsync();
            if (IsAdmin)
            {
                await LoadCustomersAsync();
                await LoadRoomsAsync();
            }
        }

        private async Task LoadBookingsAsync()
        {
            try
            {
                IsLoading = true;
                IEnumerable<BookingDto> bookings;
                
                if (IsAdmin)
                {
                    bookings = await _bookingService.GetAllBookingsAsync();
                }
                else
                {
                    bookings = await _bookingService.GetBookingsByCustomerAsync(_currentUser.CustomerId);
                }

                Bookings.Clear();
                foreach (var booking in bookings)
                {
                    Bookings.Add(booking);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task LoadCustomersAsync()
        {
            try
            {
                var customers = await _customerService.GetAllCustomersAsync();
                Customers.Clear();
                foreach (var customer in customers.Where(c => c.CustomerStatus == 1))
                {
                    Customers.Add(customer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task LoadRoomsAsync()
        {
            try
            {
                var rooms = await _roomService.GetAvailableRoomsAsync();
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
        }

        private async Task AddBookingAsync()
        {
            var dialog = new Views.BookingDialog(Customers, Rooms);
            if (dialog.ShowDialog() == true && dialog.Booking != null)
            {
                try
                {
                    IsLoading = true;
                    var newBooking = await _bookingService.CreateBookingAsync(dialog.Booking);
                    Bookings.Add(newBooking);
                    MessageBox.Show("Booking created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating booking: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        private async Task EditBookingAsync()
        {
            if (SelectedBooking == null) return;

            var dialog = new Views.BookingDialog(Customers, Rooms, SelectedBooking);
            if (dialog.ShowDialog() == true && dialog.BookingUpdate != null)
            {
                try
                {
                    IsLoading = true;
                    var updatedBooking = await _bookingService.UpdateBookingAsync(dialog.BookingUpdate);
                    var index = Bookings.ToList().FindIndex(b => b.BookingReservationId == updatedBooking.BookingReservationId);
                    if (index >= 0)
                    {
                        Bookings[index] = updatedBooking;
                    }
                    MessageBox.Show("Booking updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating booking: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        private async Task DeleteBookingAsync()
        {
            if (SelectedBooking == null) return;

            var result = MessageBox.Show($"Are you sure you want to delete booking #{SelectedBooking.BookingReservationId}?", 
                "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    IsLoading = true;
                    var success = await _bookingService.DeleteBookingAsync(SelectedBooking.BookingReservationId);
                    if (success)
                    {
                        Bookings.Remove(SelectedBooking);
                        SelectedBooking = null;
                        MessageBox.Show("Booking deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting booking: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        private async Task SearchBookingsAsync()
        {
            try
            {
                IsLoading = true;
                if (string.IsNullOrWhiteSpace(SearchText))
                {
                    await LoadBookingsAsync();
                }
                else
                {
                    var bookings = await _bookingService.SearchBookingsAsync(SearchText);
                    if (!IsAdmin)
                    {
                        bookings = bookings.Where(b => b.CustomerId == _currentUser.CustomerId);
                    }
                    
                    Bookings.Clear();
                    foreach (var booking in bookings)
                    {
                        Bookings.Add(booking);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching bookings: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task ViewBookingDetailsAsync()
        {
            if (SelectedBooking == null) return;

            try
            {
                var booking = await _bookingService.GetBookingByIdAsync(SelectedBooking.BookingReservationId);
                if (booking != null)
                {
                    var dialog = new Views.BookingDetailsDialog(booking);
                    dialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking details: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
