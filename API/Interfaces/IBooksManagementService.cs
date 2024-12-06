using API.Data.Entities;
using API.Dto.Request;

namespace API.Interfaces
{
    public interface IBooksManagementService
    {
        Task<Book> CreateBookWithDetails(CreateBookWithDetailsDto request);
    }
}