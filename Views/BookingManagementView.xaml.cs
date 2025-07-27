using DuongTuanKiet_SE18D07_A02.ViewModels;
using DuongTuanKietWPF.Business.DTOs;
using System.Windows.Controls;

namespace DuongTuanKiet_SE18D07_A02.Views
{
    public partial class BookingManagementView : UserControl
    {
        public BookingManagementView(CustomerDto currentUser)
        {
            InitializeComponent();
            DataContext = new BookingManagementViewModel(currentUser);
        }
    }
}
