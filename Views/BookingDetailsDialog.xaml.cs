using DuongTuanKietWPF.Business.DTOs;
using System.Windows;

namespace DuongTuanKiet_SE18D07_A02.Views
{
    public partial class BookingDetailsDialog : Window
    {
        public BookingDetailsDialog(BookingDto booking)
        {
            InitializeComponent();
            DataContext = booking;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
