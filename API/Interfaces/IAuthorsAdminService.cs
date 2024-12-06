using API.Data.Entities;

namespace API.Interfaces
{
    public interface IAuthorsAdminService
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorById(int id);
        Task<List<Author>> CreateAuthors(List<Author> authors);
        Task UpdateAuthor(Author author);
        Task DeleteAuthor(Author author);
    }
}
