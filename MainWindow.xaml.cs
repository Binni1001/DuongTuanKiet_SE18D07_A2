using DuongTuanKiet_SE18D07_A02.ViewModels;
using DuongTuanKietWPF.Business.DTOs;
using System.Windows;

namespace DuongTuanKiet_SE18D07_A02
{
    public partial class MainWindow : Window
    {
        public MainWindow(CustomerDto currentUser)
        {
            InitializeComponent();
            DataContext = new MainViewModel(currentUser);
        }
    }
}