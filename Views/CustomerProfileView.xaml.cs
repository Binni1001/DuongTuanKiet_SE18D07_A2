using DuongTuanKiet_SE18D07_A02.ViewModels;
using DuongTuanKietWPF.Business.DTOs;
using System.Windows.Controls;

namespace DuongTuanKiet_SE18D07_A02.Views
{
    public partial class CustomerProfileView : UserControl
    {
        public CustomerProfileView(CustomerDto currentUser)
        {
            InitializeComponent();
            DataContext = new CustomerProfileViewModel(currentUser);
        }
    }
}
