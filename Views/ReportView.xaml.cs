using DuongTuanKiet_SE18D07_A02.ViewModels;
using System.Windows.Controls;

namespace DuongTuanKiet_SE18D07_A02.Views
{
    public partial class ReportView : UserControl
    {
        public ReportView()
        {
            InitializeComponent();
            DataContext = new ReportViewModel();
        }
    }
}
