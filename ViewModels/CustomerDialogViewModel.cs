using DuongTuanKietWPF.Business.DTOs;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DuongTuanKiet_SE18D07_A02.ViewModels
{
    public class CustomerDialogViewModel : BaseViewModel
    {
        private int _customerId;
        private string _customerFullName = string.Empty;
        private string _emailAddress = string.Empty;
        private string? _telephone;
        private DateOnly? _customerBirthday;
        private string _password = string.Empty;
        private byte _customerStatus = 1;
        private string _validationErrors = string.Empty;
        private bool _isNewCustomer;

        public CustomerDialogViewModel(CustomerDto? customer = null)
        {
            IsNewCustomer = customer == null;
            
            if (customer != null)
            {
                CustomerId = customer.CustomerId;
                CustomerFullName = customer.CustomerFullName;
                EmailAddress = customer.EmailAddress;
                Telephone = customer.Telephone;
                CustomerBirthday = customer.CustomerBirthday;
                CustomerStatus = customer.CustomerStatus;
            }
        }

        public string Title => IsNewCustomer ? "Add New Customer" : "Edit Customer";

        public int CustomerId
        {
            get => _customerId;
            set => SetProperty(ref _customerId, value);
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

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public byte CustomerStatus
        {
            get => _customerStatus;
            set => SetProperty(ref _customerStatus, value);
        }

        public string ValidationErrors
        {
            get => _validationErrors;
            set => SetProperty(ref _validationErrors, value);
        }

        public bool IsNewCustomer
        {
            get => _isNewCustomer;
            set => SetProperty(ref _isNewCustomer, value);
        }

        public bool ValidateInput()
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

            // Validate Password (only for new customers)
            if (IsNewCustomer)
            {
                if (string.IsNullOrWhiteSpace(Password))
                    errors.AppendLine("Password is required.");
                else if (Password.Length < 6 || Password.Length > 50)
                    errors.AppendLine("Password must be between 6 and 50 characters.");
            }

            ValidationErrors = errors.ToString().Trim();
            return string.IsNullOrEmpty(ValidationErrors);
        }

        public CustomerDto ToCustomerDto()
        {
            return new CustomerDto
            {
                CustomerId = CustomerId,
                CustomerFullName = CustomerFullName,
                EmailAddress = EmailAddress,
                Telephone = Telephone,
                CustomerBirthday = CustomerBirthday,
                Password = Password,
                CustomerStatus = CustomerStatus
            };
        }
    }
}
