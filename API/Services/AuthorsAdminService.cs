using API.Data.Entities;
using API.Interfaces;

namespace API.Services
{
    public class AuthorsAdminService : IAuthorsAdminService
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorsAdminService(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            if (authors == null || !authors.Any())
                throw new Exception("No authors found!");

            return authors;
        }

        public async Task<Author> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
                throw new Exception("Author not found!");

            return author;
        }

        public async Task<Author> CreateAuthor(Author author)
        {
            if (string.IsNullOrWhiteSpace(author.FirstName) || string.IsNullOrWhiteSpace(author.LastName))
                throw new Exception("First Name and Last Name must be provided!");

            var newAuthor = await _authorRepository.AddAsync(author);

            return newAuthor;
        }

        public async Task UpdateAuthor(Author author)
        {
            await _authorRepository.UpdateAsync(author);
        }

        public async Task DeleteAuthor(Author author)
        {
            await _authorRepository.DeleteAsync(author);
        }
    }
}
