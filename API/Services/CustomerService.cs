using API.Data;
using API.Dto;
using API.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CustomerDto> GetCustomerAsync(int userId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.UserId == userId);
            if (customer == null) throw new Exception("Customer not found");

            var customerDto = new CustomerDto
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                City = customer.City,
                PostalCode = customer.PostalCode,
                UserId = customer.UserId,
            };

            return customerDto;
        }
    }
}
