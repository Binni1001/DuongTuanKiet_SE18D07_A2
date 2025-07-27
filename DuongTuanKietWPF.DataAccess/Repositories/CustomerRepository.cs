using DuongTuanKietWPF.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DuongTuanKietWPF.DataAccess.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(FUMiniHotelManagementContext context) : base(context)
        {
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.EmailAddress == email);
        }

        public async Task<Customer?> AuthenticateAsync(string email, string password)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"CustomerRepository: Authenticating {email} with password {password}");
                System.Diagnostics.Debug.WriteLine($"CustomerRepository: Connection string: {_context.Database.GetConnectionString()}");

                var customer = await _dbSet.FirstOrDefaultAsync(c =>
                    c.EmailAddress == email &&
                    c.Password == password &&
                    c.CustomerStatus == 1);

                System.Diagnostics.Debug.WriteLine($"CustomerRepository: Found customer: {customer?.CustomerFullName ?? "NULL"}");
                return customer;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CustomerRepository: Database error - {ex.Message}");
                throw;
            }
        }

        public async Task<bool> IsEmailExistsAsync(string email, int? excludeCustomerId = null)
        {
            if (excludeCustomerId.HasValue)
            {
                return await _dbSet.AnyAsync(c => c.EmailAddress == email && c.CustomerId != excludeCustomerId.Value);
            }
            return await _dbSet.AnyAsync(c => c.EmailAddress == email);
        }

        public async Task<IEnumerable<Customer>> SearchCustomersAdvancedAsync(string searchTerm)
        {
            return await _dbSet.Where(c =>
                c.CustomerFullName.Contains(searchTerm) ||
                c.EmailAddress.Contains(searchTerm) ||
                (c.Telephone != null && c.Telephone.Contains(searchTerm))
            ).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomersByStatusAsync(byte status)
        {
            return await _dbSet.Where(c => c.CustomerStatus == status).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomersWithBookingsAsync()
        {
            return await _dbSet
                .Include(c => c.BookingReservations)
                .Where(c => c.BookingReservations.Any())
                .ToListAsync();
        }
    }
}
