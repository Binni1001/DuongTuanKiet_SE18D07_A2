using DuongTuanKietWPF.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace DuongTuanKietWPF.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FUMiniHotelManagementContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(FUMiniHotelManagementContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Rooms = new RoomRepository(_context);
            RoomTypes = new RoomTypeRepository(_context);
            Bookings = new BookingRepository(_context);
            BookingDetails = new BookingDetailRepository(_context);
        }

        public ICustomerRepository Customers { get; private set; }
        public IRoomRepository Rooms { get; private set; }
        public IRoomTypeRepository RoomTypes { get; private set; }
        public IBookingRepository Bookings { get; private set; }
        public IBookingDetailRepository BookingDetails { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
