using API.Data;
using API.Data.Entities;
using API.Dto.Request;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BooksManagementService : IBooksManagementService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<Publisher> _publisherRepository;
        public BooksManagementService(
            IRepository<Book> booksRepository,
            IRepository<Author> authorRepository,
            IRepository<Publisher> publisherRepository,
            ApplicationDbContext context)
        {
            _context = context;
            _bookRepository = booksRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        public Task<Book> CreateBookAsync(BookCreateDto bookDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBookAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book?> GetBookByIdAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<Book> UpdateBookAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
