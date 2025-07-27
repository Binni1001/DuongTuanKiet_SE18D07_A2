using DuongTuanKiet_SE18D07_A02.Commands;
using DuongTuanKietWPF.Business.DTOs;
using DuongTuanKietWPF.Business.Services;
using DuongTuanKietWPF.DataAccess.Configuration;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DuongTuanKiet_SE18D07_A02.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ICustomerService _customerService;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private string _errorMessage = string.Empty;
        private bool _isLoading;

        public LoginViewModel()
        {
            _customerService = ServiceFactory.GetCustomerService();
            LoginCommand = new RelayCommand(async () => await LoginAsync(), CanLogin);
            ExitCommand = new RelayCommand(() => Application.Current.Shutdown());
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand ExitCommand { get; }

        public event EventHandler<CustomerDto>? LoginSuccessful;

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Email) && 
                   !string.IsNullOrWhiteSpace(Password) && 
                   !IsLoading;
        }

        private async Task LoginAsync()
        {
            try
            {
                IsLoading = true;
                ErrorMessage = string.Empty;

                // Check admin account first
                var adminAccount = ConfigurationHelper.GetSection<AdminAccount>("AdminAccount");
                if (Email == adminAccount.Email && Password == adminAccount.Password)
                {
                    var adminCustomer = new CustomerDto
                    {
                        CustomerId = 0,
                        CustomerFullName = "Administrator",
                        EmailAddress = adminAccount.Email,
                        CustomerStatus = 1
                    };
                    LoginSuccessful?.Invoke(this, adminCustomer);
                    return;
                }

                // Check customer account
                var loginDto = new CustomerLoginDto
                {
                    EmailAddress = Email,
                    Password = Password
                };

                System.Diagnostics.Debug.WriteLine("Attempting customer authentication...");
                var customer = await _customerService.AuthenticateAsync(loginDto);
                if (customer != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Authentication successful for: {customer.CustomerFullName}");
                    LoginSuccessful?.Invoke(this, customer);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Authentication failed - no matching user found");
                    ErrorMessage = "Invalid email or password.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Login failed: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
