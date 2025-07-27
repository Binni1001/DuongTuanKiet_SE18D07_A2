using DuongTuanKietWPF.Business.DTOs;
using System.Collections.ObjectModel;
using System.Windows;

namespace DuongTuanKiet_SE18D07_A02.Views
{
    public partial class BookingDialog : Window
    {
        public BookingDialog(ObservableCollection<CustomerDto> customers, ObservableCollection<RoomDto> rooms, BookingDto? booking = null)
        {
            InitializeComponent();
        }

        public BookingCreateDto? Booking { get; private set; }
        public BookingUpdateDto? BookingUpdate { get; private set; }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // For now, just close the dialog
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
