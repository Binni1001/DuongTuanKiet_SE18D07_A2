using DuongTuanKiet_SE18D07_A02.Commands;
using DuongTuanKietWPF.Business.DTOs;
using System;
using System.Windows;
using System.Windows.Input;

namespace DuongTuanKiet_SE18D07_A02.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private CustomerDto _currentUser;
        private object? _currentView;
        private string _statusMessage = "Ready";

        public MainViewModel(CustomerDto currentUser)
        {
            _currentUser = currentUser;
            
            ShowCustomerManagementCommand = new RelayCommand(ShowCustomerManagement);
            ShowRoomManagementCommand = new RelayCommand(ShowRoomManagement);
            ShowBookingManagementCommand = new RelayCommand(ShowBookingManagement);
            ShowReportsCommand = new RelayCommand(ShowReports);
            ShowProfileCommand = new RelayCommand(ShowProfile);
            ShowBookingHistoryCommand = new RelayCommand(ShowBookingHistory);
            LogoutCommand = new RelayCommand(Logout);

            // Show default view based on user role
            if (IsAdmin)
            {
                ShowCustomerManagement();
            }
            else
            {
                ShowProfile();
            }
        }

        public CustomerDto CurrentUser
        {
            get => _currentUser;
            set => SetProperty(ref _currentUser, value);
        }

        public object? CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        public bool IsAdmin => CurrentUser.CustomerId == 0 || CurrentUser.EmailAddress == "admin@FUMiniHotelSystem.com";

        public ICommand ShowCustomerManagementCommand { get; }
        public ICommand ShowRoomManagementCommand { get; }
        public ICommand ShowBookingManagementCommand { get; }
        public ICommand ShowReportsCommand { get; }
        public ICommand ShowProfileCommand { get; }
        public ICommand ShowBookingHistoryCommand { get; }
        public ICommand LogoutCommand { get; }

        private void ShowCustomerManagement()
        {
            StatusMessage = "Customer Management";
            CurrentView = new Views.CustomerManagementView();
        }

        private void ShowRoomManagement()
        {
            if (!IsAdmin) return;

            StatusMessage = "Room Management";
            CurrentView = new Views.RoomManagementView();
        }

        private void ShowBookingManagement()
        {
            StatusMessage = "Booking Management";
            CurrentView = new Views.BookingManagementView(CurrentUser);
        }

        private void ShowReports()
        {
            if (!IsAdmin) return;

            StatusMessage = "Reports";
            CurrentView = new Views.ReportView();
        }

        private void ShowProfile()
        {
            StatusMessage = "My Profile";
            CurrentView = new Views.CustomerProfileView(CurrentUser);
        }

        private void ShowBookingHistory()
        {
            StatusMessage = "My Booking History";
            CurrentView = new Views.BookingManagementView(CurrentUser);
        }

        private void Logout()
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var loginWindow = new Views.LoginWindow();
                loginWindow.Show();

                // Close current window
                Application.Current.MainWindow?.Close();
            }
        }
    }
}
