using DuongTuanKiet_SE18D07_A02.ViewModels;
using System.Windows.Controls;

namespace DuongTuanKiet_SE18D07_A02.Views
{
    public partial class CustomerManagementView : UserControl
    {
        public CustomerManagementView()
        {
            InitializeComponent();
            DataContext = new CustomerManagementViewModel();
        }
    }
}
