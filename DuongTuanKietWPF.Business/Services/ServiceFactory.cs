using DuongTuanKietWPF.DataAccess;
using DuongTuanKietWPF.DataAccess.Configuration;
using DuongTuanKietWPF.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;

namespace DuongTuanKietWPF.Business.Services
{
    public static class ServiceFactory
    {
        private static FUMiniHotelManagementContext? _context;

        public static FUMiniHotelManagementContext GetDbContext()
        {
            if (_context == null)
            {
                var connectionString = ConfigurationHelper.GetConnectionString();
                var optionsBuilder = new DbContextOptionsBuilder<FUMiniHotelManagementContext>();
                optionsBuilder.UseSqlServer(connectionString);
                _context = new FUMiniHotelManagementContext(optionsBuilder.Options);
            }
            return _context;
        }

        public static IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(GetDbContext());
        }

        public static ICustomerService GetCustomerService()
        {
            return new CustomerService(GetUnitOfWork());
        }

        public static IRoomService GetRoomService()
        {
            return new RoomService(GetUnitOfWork());
        }

        public static IBookingService GetBookingService()
        {
            return new BookingService(GetUnitOfWork());
        }

        public static void DisposeContext()
        {
            _context?.Dispose();
            _context = null;
        }
    }
}
