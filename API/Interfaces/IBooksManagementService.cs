using API.Data.Entities;
using API.Dto.Request;

namespace API.Interfaces
{
    public interface IBooksManagementService
    {
        Task<Book> CreateBookAsync(BookCreateDto bookDto);
        Task<Book> UpdateBookAsync(int id);
        Task DeleteBookAsync(int bookId);
        Task<Book?> GetBookByIdAsync(int bookId);
        Task<IEnumerable<Book>> GetAllBooksAsync();
    }
}