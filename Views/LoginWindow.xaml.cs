using DuongTuanKiet_SE18D07_A02.ViewModels;
using DuongTuanKietWPF.Business.DTOs;
using System.Windows;
using System.Windows.Controls;

namespace DuongTuanKiet_SE18D07_A02.Views
{
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel _viewModel;

        public LoginWindow()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel();
            DataContext = _viewModel;
            _viewModel.LoginSuccessful += OnLoginSuccessful;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                _viewModel.Password = passwordBox.Password;
            }
        }

        private void OnLoginSuccessful(object? sender, CustomerDto customer)
        {
            var mainWindow = new MainWindow(customer);
            mainWindow.Show();
            this.Close();
        }
    }
}
