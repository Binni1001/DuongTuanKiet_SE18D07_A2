using DuongTuanKietWPF.Business.DTOs;
using DuongTuanKietWPF.Business.Helpers;
using DuongTuanKietWPF.DataAccess.Models;
using DuongTuanKietWPF.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuongTuanKietWPF.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            return MappingHelper.ToDto(customers);
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(customerId);
            return customer != null ? MappingHelper.ToDto(customer) : null;
        }

        public async Task<CustomerDto?> GetCustomerByEmailAsync(string email)
        {
            var customer = await _unitOfWork.Customers.GetByEmailAsync(email);
            return customer != null ? MappingHelper.ToDto(customer) : null;
        }

        public async Task<CustomerDto?> AuthenticateAsync(CustomerLoginDto loginDto)
        {
            var customer = await _unitOfWork.Customers.AuthenticateAsync(loginDto.EmailAddress, loginDto.Password);
            return customer != null ? MappingHelper.ToDto(customer) : null;
        }

        public async Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto)
        {
            // Check if email already exists
            if (await _unitOfWork.Customers.IsEmailExistsAsync(customerCreateDto.EmailAddress))
            {
                throw new InvalidOperationException("Email address already exists.");
            }

            var customer = MappingHelper.ToEntity(customerCreateDto);
            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return MappingHelper.ToDto(customer);
        }

        public async Task<CustomerDto> UpdateCustomerAsync(CustomerUpdateDto customerUpdateDto)
        {
            var existingCustomer = await _unitOfWork.Customers.GetByIdAsync(customerUpdateDto.CustomerId);
            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            // Check if email already exists (excluding current customer)
            if (await _unitOfWork.Customers.IsEmailExistsAsync(customerUpdateDto.EmailAddress, customerUpdateDto.CustomerId))
            {
                throw new InvalidOperationException("Email address already exists.");
            }

            MappingHelper.UpdateEntity(existingCustomer, customerUpdateDto);
            _unitOfWork.Customers.Update(existingCustomer);
            await _unitOfWork.SaveChangesAsync();

            return MappingHelper.ToDto(existingCustomer);
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(customerId);
            if (customer == null)
            {
                return false;
            }

            // Check if customer has any bookings
            var bookings = await _unitOfWork.Bookings.GetBookingsByCustomerAsync(customerId);
            if (bookings.Any())
            {
                // Don't delete, just deactivate
                customer.CustomerStatus = 0;
                _unitOfWork.Customers.Update(customer);
            }
            else
            {
                _unitOfWork.Customers.Delete(customer);
            }

            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CustomerDto>> SearchCustomersAsync(string searchTerm)
        {
            var customers = await _unitOfWork.Customers.FindAsync(c =>
                c.CustomerFullName.Contains(searchTerm) ||
                c.EmailAddress.Contains(searchTerm) ||
                (c.Telephone != null && c.Telephone.Contains(searchTerm)));

            return MappingHelper.ToDto(customers);
        }

        public async Task<bool> IsEmailExistsAsync(string email, int? excludeCustomerId = null)
        {
            return await _unitOfWork.Customers.IsEmailExistsAsync(email, excludeCustomerId);
        }

        public async Task<bool> ChangePasswordAsync(int customerId, string currentPassword, string newPassword)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(customerId);
            if (customer == null || customer.Password != currentPassword)
            {
                return false;
            }

            customer.Password = newPassword;
            _unitOfWork.Customers.Update(customer);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
