using DuongTuanKiet_SE18D07_A02.ViewModels;
using DuongTuanKietWPF.Business.DTOs;
using System.Windows;
using System.Windows.Controls;

namespace DuongTuanKiet_SE18D07_A02.Views
{
    public partial class CustomerDialog : Window
    {
        private readonly CustomerDialogViewModel _viewModel;

        public CustomerDialog(CustomerDto? customer = null)
        {
            InitializeComponent();
            _viewModel = new CustomerDialogViewModel(customer);
            DataContext = _viewModel;
        }

        public CustomerDto? Customer { get; private set; }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                _viewModel.Password = passwordBox.Password;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.ValidateInput())
            {
                Customer = _viewModel.ToCustomerDto();
                DialogResult = true;
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
