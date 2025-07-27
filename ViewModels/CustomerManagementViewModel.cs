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
    public class CustomerManagementViewModel : BaseViewModel
    {
        private readonly ICustomerService _customerService;
        private ObservableCollection<CustomerDto> _customers = new();
        private CustomerDto? _selectedCustomer;
        private string _searchText = string.Empty;
        private bool _isLoading;

        public CustomerManagementViewModel()
        {
            _customerService = ServiceFactory.GetCustomerService();
            
            AddCommand = new RelayCommand(async () => await AddCustomerAsync());
            EditCommand = new RelayCommand(async () => await EditCustomerAsync(), () => SelectedCustomer != null);
            DeleteCommand = new RelayCommand(async () => await DeleteCustomerAsync(), () => SelectedCustomer != null);
            SearchCommand = new RelayCommand(async () => await SearchCustomersAsync());
            RefreshCommand = new RelayCommand(async () => await LoadCustomersAsync());

            _ = LoadCustomersAsync();
        }

        public ObservableCollection<CustomerDto> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }

        public CustomerDto? SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
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

        private async Task LoadCustomersAsync()
        {
            try
            {
                IsLoading = true;
                var customers = await _customerService.GetAllCustomersAsync();
                Customers.Clear();
                foreach (var customer in customers)
                {
                    Customers.Add(customer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task AddCustomerAsync()
        {
            var dialog = new Views.CustomerDialog();
            if (dialog.ShowDialog() == true && dialog.Customer != null)
            {
                try
                {
                    IsLoading = true;
                    var createDto = new CustomerCreateDto
                    {
                        CustomerFullName = dialog.Customer.CustomerFullName,
                        Telephone = dialog.Customer.Telephone,
                        EmailAddress = dialog.Customer.EmailAddress,
                        CustomerBirthday = dialog.Customer.CustomerBirthday,
                        Password = dialog.Customer.Password
                    };

                    var newCustomer = await _customerService.CreateCustomerAsync(createDto);
                    Customers.Add(newCustomer);
                    MessageBox.Show("Customer added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        private async Task EditCustomerAsync()
        {
            if (SelectedCustomer == null) return;

            var dialog = new Views.CustomerDialog(SelectedCustomer);
            if (dialog.ShowDialog() == true && dialog.Customer != null)
            {
                try
                {
                    IsLoading = true;
                    var updateDto = new CustomerUpdateDto
                    {
                        CustomerId = dialog.Customer.CustomerId,
                        CustomerFullName = dialog.Customer.CustomerFullName,
                        Telephone = dialog.Customer.Telephone,
                        EmailAddress = dialog.Customer.EmailAddress,
                        CustomerBirthday = dialog.Customer.CustomerBirthday,
                        CustomerStatus = dialog.Customer.CustomerStatus
                    };

                    var updatedCustomer = await _customerService.UpdateCustomerAsync(updateDto);
                    var index = Customers.ToList().FindIndex(c => c.CustomerId == updatedCustomer.CustomerId);
                    if (index >= 0)
                    {
                        Customers[index] = updatedCustomer;
                    }
                    MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        private async Task DeleteCustomerAsync()
        {
            if (SelectedCustomer == null) return;

            var result = MessageBox.Show($"Are you sure you want to delete customer '{SelectedCustomer.CustomerFullName}'?", 
                "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    IsLoading = true;
                    var success = await _customerService.DeleteCustomerAsync(SelectedCustomer.CustomerId);
                    if (success)
                    {
                        Customers.Remove(SelectedCustomer);
                        SelectedCustomer = null;
                        MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        private async Task SearchCustomersAsync()
        {
            try
            {
                IsLoading = true;
                if (string.IsNullOrWhiteSpace(SearchText))
                {
                    await LoadCustomersAsync();
                }
                else
                {
                    var customers = await _customerService.SearchCustomersAsync(SearchText);
                    Customers.Clear();
                    foreach (var customer in customers)
                    {
                        Customers.Add(customer);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching customers: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
