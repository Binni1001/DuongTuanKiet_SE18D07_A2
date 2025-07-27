using DuongTuanKietWPF.DataAccess.Models;

namespace DuongTuanKietWPF.DataAccess.Repositories
{
    public class RoomTypeRepository : GenericRepository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(FUMiniHotelManagementContext context) : base(context)
        {
        }
    }
}
