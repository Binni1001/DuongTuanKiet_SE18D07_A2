using DuongTuanKietWPF.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DuongTuanKietWPF.DataAccess.Repositories
{
    public interface IBookingDetailRepository : IGenericRepository<BookingDetail>
    {
        Task<IEnumerable<BookingDetail>> GetBookingDetailsByBookingIdAsync(int bookingReservationId);
        Task DeleteByBookingIdAsync(int bookingReservationId);
    }
}
