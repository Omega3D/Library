using API.Data.Entities;

namespace API.Interfaces
{
    public interface IBooksAdminService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookById(int id);
        Task<Book> CreateBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(Book book);
    }
}
