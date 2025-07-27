using DuongTuanKietWPF.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DuongTuanKietWPF.DataAccess.Repositories
{
    public interface IBookingRepository : IGenericRepository<BookingReservation>
    {
        Task<IEnumerable<BookingReservation>> GetBookingsWithDetailsAsync();
        Task<BookingReservation?> GetBookingWithDetailsAsync(int bookingId);
        Task<IEnumerable<BookingReservation>> GetBookingsByCustomerAsync(int customerId);
        Task<IEnumerable<BookingReservation>> GetBookingsByDateRangeAsync(DateOnly startDate, DateOnly endDate);
        Task<IEnumerable<BookingReservation>> GetBookingsForReportAsync(DateOnly startDate, DateOnly endDate);
    }
}
