using DuongTuanKietWPF.Business.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DuongTuanKietWPF.Business.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto?> GetCustomerByIdAsync(int customerId);
        Task<CustomerDto?> GetCustomerByEmailAsync(string email);
        Task<CustomerDto?> AuthenticateAsync(CustomerLoginDto loginDto);
        Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto);
        Task<CustomerDto> UpdateCustomerAsync(CustomerUpdateDto customerUpdateDto);
        Task<bool> DeleteCustomerAsync(int customerId);
        Task<IEnumerable<CustomerDto>> SearchCustomersAsync(string searchTerm);
        Task<bool> IsEmailExistsAsync(string email, int? excludeCustomerId = null);
        Task<bool> ChangePasswordAsync(int customerId, string currentPassword, string newPassword);
    }
}
