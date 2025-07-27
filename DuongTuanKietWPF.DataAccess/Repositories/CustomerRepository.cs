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
            return await _dbSet.FirstOrDefaultAsync(c => 
                c.EmailAddress == email && 
                c.Password == password && 
                c.CustomerStatus == 1);
        }

        public async Task<bool> IsEmailExistsAsync(string email, int? excludeCustomerId = null)
        {
            if (excludeCustomerId.HasValue)
            {
                return await _dbSet.AnyAsync(c => c.EmailAddress == email && c.CustomerId != excludeCustomerId.Value);
            }
            return await _dbSet.AnyAsync(c => c.EmailAddress == email);
        }
    }
}
