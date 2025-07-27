using DuongTuanKietWPF.DataAccess.Models;
using System.Threading.Tasks;

namespace DuongTuanKietWPF.DataAccess.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer?> GetByEmailAsync(string email);
        Task<Customer?> AuthenticateAsync(string email, string password);
        Task<bool> IsEmailExistsAsync(string email, int? excludeCustomerId = null);
    }
}
