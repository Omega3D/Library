using API.Dto;

namespace API.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerAsync(int userId);
    }
}
