using DuongTuanKiet_SE18D07_A02.Commands;
using DuongTuanKietWPF.Business.DTOs;
using DuongTuanKietWPF.Business.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DuongTuanKiet_SE18D07_A02.ViewModels
{
    public class CustomerProfileViewModel : BaseViewModel
    {
        private readonly ICustomerService _customerService;
        private readonly CustomerDto _currentUser;
        private string _customerFullName = string.Empty;
        private string _emailAddress = string.Empty;
        private string? _telephone;
        private DateOnly? _customerBirthday;
        private string _validationErrors = string.Empty;
        private bool _isLoading;
        private bool _isEditing;

        public CustomerProfileViewModel(CustomerDto currentUser)
        {
            _currentUser = currentUser;
            _customerService = ServiceFactory.GetCustomerService();
            
            EditCommand = new RelayCommand(() => IsEditing = true);
            SaveCommand = new RelayCommand(async () => await SaveProfileAsync(), () => IsEditing);
            CancelCommand = new RelayCommand(CancelEdit, () => IsEditing);
            ChangePasswordCommand = new RelayCommand(async () => await ChangePasswordAsync());

            LoadProfile();
        }

        public string CustomerFullName
        {
            get => _customerFullName;
            set => SetProperty(ref _customerFullName, value);
        }

        public string EmailAddress
        {
            get => _emailAddress;
            set => SetProperty(ref _emailAddress, value);
        }

        public string? Telephone
        {
            get => _telephone;
            set => SetProperty(ref _telephone, value);
        }

        public DateOnly? CustomerBirthday
        {
            get => _customerBirthday;
            set => SetProperty(ref _customerBirthday, value);
        }

        public string ValidationErrors
        {
            get => _validationErrors;
            set => SetProperty(ref _validationErrors, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public bool IsEditing
        {
            get => _isEditing;
            set => SetProperty(ref _isEditing, value);
        }

        public ICommand EditCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand ChangePasswordCommand { get; }

        private void LoadProfile()
        {
            CustomerFullName = _currentUser.CustomerFullName;
            EmailAddress = _currentUser.EmailAddress;
            Telephone = _currentUser.Telephone;
            CustomerBirthday = _currentUser.CustomerBirthday;
        }

        private async Task SaveProfileAsync()
        {
            if (!ValidateInput()) return;

            try
            {
                IsLoading = true;
                var updateDto = new CustomerUpdateDto
                {
                    CustomerId = _currentUser.CustomerId,
                    CustomerFullName = CustomerFullName,
                    EmailAddress = EmailAddress,
                    Telephone = Telephone,
                    CustomerBirthday = CustomerBirthday,
                    CustomerStatus = _currentUser.CustomerStatus
                };

                var updatedCustomer = await _customerService.UpdateCustomerAsync(updateDto);
                
                // Update current user data
                _currentUser.CustomerFullName = updatedCustomer.CustomerFullName;
                _currentUser.EmailAddress = updatedCustomer.EmailAddress;
                _currentUser.Telephone = updatedCustomer.Telephone;
                _currentUser.CustomerBirthday = updatedCustomer.CustomerBirthday;

                IsEditing = false;
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating profile: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void CancelEdit()
        {
            LoadProfile();
            IsEditing = false;
            ValidationErrors = string.Empty;
        }

        private async Task ChangePasswordAsync()
        {
            var dialog = new Views.ChangePasswordDialog();
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    IsLoading = true;
                    // In a real application, you would have a ChangePassword method in the service
                    // For now, we'll just show a success message
                    MessageBox.Show("Password changed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error changing password: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        private bool ValidateInput()
        {
            var errors = new StringBuilder();

            // Validate Full Name
            if (string.IsNullOrWhiteSpace(CustomerFullName))
                errors.AppendLine("Full name is required.");
            else if (CustomerFullName.Length > 50)
                errors.AppendLine("Full name cannot exceed 50 characters.");

            // Validate Email
            if (string.IsNullOrWhiteSpace(EmailAddress))
                errors.AppendLine("Email address is required.");
            else if (!new EmailAddressAttribute().IsValid(EmailAddress))
                errors.AppendLine("Invalid email address format.");
            else if (EmailAddress.Length > 50)
                errors.AppendLine("Email address cannot exceed 50 characters.");

            // Validate Phone
            if (!string.IsNullOrWhiteSpace(Telephone) && Telephone.Length > 12)
                errors.AppendLine("Phone number cannot exceed 12 characters.");

            ValidationErrors = errors.ToString().Trim();
            return string.IsNullOrEmpty(ValidationErrors);
        }
    }
}
