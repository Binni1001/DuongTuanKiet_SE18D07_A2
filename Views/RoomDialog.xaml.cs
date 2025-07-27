using DuongTuanKiet_SE18D07_A02.ViewModels;
using DuongTuanKietWPF.Business.DTOs;
using System.Collections.ObjectModel;
using System.Windows;

namespace DuongTuanKiet_SE18D07_A02.Views
{
    public partial class RoomDialog : Window
    {
        private readonly RoomDialogViewModel _viewModel;

        public RoomDialog(ObservableCollection<RoomTypeDto> roomTypes, RoomDto? room = null)
        {
            InitializeComponent();
            _viewModel = new RoomDialogViewModel(roomTypes, room);
            DataContext = _viewModel;
        }

        public RoomDto? Room { get; private set; }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.ValidateInput())
            {
                Room = _viewModel.ToRoomDto();
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
