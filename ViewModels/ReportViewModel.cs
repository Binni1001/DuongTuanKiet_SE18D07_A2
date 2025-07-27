using DuongTuanKiet_SE18D07_A02.Commands;
using DuongTuanKietWPF.Business.DTOs;
using DuongTuanKietWPF.Business.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DuongTuanKiet_SE18D07_A02.ViewModels
{
    public class ReportViewModel : BaseViewModel
    {
        private readonly IBookingService _bookingService;
        private ObservableCollection<BookingReportDto> _reportData = new();
        private DateOnly _startDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));
        private DateOnly _endDate = DateOnly.FromDateTime(DateTime.Now);
        private bool _isLoading;
        private decimal _totalRevenue;
        private int _totalBookings;
        private string _reportSummary = string.Empty;

        public ReportViewModel()
        {
            _bookingService = ServiceFactory.GetBookingService();
            
            GenerateReportCommand = new RelayCommand(async () => await GenerateReportAsync());
            ExportReportCommand = new RelayCommand(async () => await ExportReportAsync(), () => ReportData.Count > 0);
            RefreshCommand = new RelayCommand(async () => await GenerateReportAsync());
        }

        public ObservableCollection<BookingReportDto> ReportData
        {
            get => _reportData;
            set => SetProperty(ref _reportData, value);
        }

        public DateOnly StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        public DateOnly EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public decimal TotalRevenue
        {
            get => _totalRevenue;
            set => SetProperty(ref _totalRevenue, value);
        }

        public int TotalBookings
        {
            get => _totalBookings;
            set => SetProperty(ref _totalBookings, value);
        }

        public string ReportSummary
        {
            get => _reportSummary;
            set => SetProperty(ref _reportSummary, value);
        }

        public ICommand GenerateReportCommand { get; }
        public ICommand ExportReportCommand { get; }
        public ICommand RefreshCommand { get; }

        private async Task GenerateReportAsync()
        {
            try
            {
                IsLoading = true;

                if (StartDate > EndDate)
                {
                    MessageBox.Show("Start date cannot be later than end date.", "Invalid Date Range", 
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var reportData = await _bookingService.GetBookingsReportAsync(StartDate, EndDate);
                
                ReportData.Clear();
                TotalRevenue = 0;
                TotalBookings = 0;

                foreach (var item in reportData)
                {
                    ReportData.Add(item);
                    TotalRevenue += item.TotalPrice ?? 0;
                    TotalBookings++;
                }

                UpdateReportSummary();
                MessageBox.Show($"Report generated successfully!\nFound {TotalBookings} bookings with total revenue of {TotalRevenue:C}", 
                    "Report Generated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void UpdateReportSummary()
        {
            var avgRevenue = TotalBookings > 0 ? TotalRevenue / TotalBookings : 0;
            var dateRange = $"{StartDate:dd/MM/yyyy} - {EndDate:dd/MM/yyyy}";
            
            ReportSummary = $"Report Period: {dateRange}\n" +
                           $"Total Bookings: {TotalBookings}\n" +
                           $"Total Revenue: {TotalRevenue:C}\n" +
                           $"Average Revenue per Booking: {avgRevenue:C}";
        }

        private async Task ExportReportAsync()
        {
            try
            {
                // Simple export to show in message box (in real app, would export to Excel/PDF)
                var exportData = "Booking Report Export\n";
                exportData += $"Generated on: {DateTime.Now:dd/MM/yyyy HH:mm}\n";
                exportData += $"Period: {StartDate:dd/MM/yyyy} - {EndDate:dd/MM/yyyy}\n\n";
                exportData += ReportSummary + "\n\n";
                exportData += "Detailed Data:\n";
                exportData += "ID\tCustomer\tDate\tTotal\n";
                
                foreach (var item in ReportData)
                {
                    exportData += $"{item.BookingReservationId}\t{item.CustomerFullName}\t{item.BookingDate:dd/MM/yyyy}\t{item.TotalPrice:C}\n";
                }

                // In a real application, you would save this to a file
                MessageBox.Show("Report export functionality would save data to Excel/PDF file.\n\nSample export data:\n" + 
                    exportData.Substring(0, Math.Min(500, exportData.Length)) + "...", 
                    "Export Report", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting report: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
