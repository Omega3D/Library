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
        private readonly IRepository<Book_Author> _bookAuthorRepository;
        public BooksManagementService(
            IRepository<Book> booksRepository,
            IRepository<Author> authorRepository,
            IRepository<Publisher> publisherRepository,
            IRepository<Book_Author> bookAuthorRepository,
            ApplicationDbContext context)
        {
            _context = context;
            _bookRepository = booksRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<Book> CreateBookWithDetails(CreateBookWithDetailsDto dto)
        {
            // Перевірка існування видавця
            var publisher = await _publisherRepository.GetByIdAsync(dto.PublisherId);
            if (publisher == null)
            {
                throw new Exception("No publisher found");
            }

            // Отримання авторів за ідентифікаторами
            var authors = await _context.Authors
                .Where(a => dto.AuthorIds.Contains(a.AuthorId))
                .ToListAsync();

            if (authors.Count != dto.AuthorIds.Count)
            {
                throw new Exception("Some authors haven't been found");
            }

            var book = new Book
            {
                Title = dto.Title,
                Description = dto.Description,
                Language = dto.Language,
                ISBN = dto.ISBN,
                Genre = dto.Genre,
                Type = dto.Type,
                PublicationYear = dto.PublicationYear,
                Price = dto.Price,
                Quantity = dto.Quantity,
                ImagePath = dto.ImagePath,
                PublisherId = dto.PublisherId,
                BookAuthors = authors.Select(author => new Book_Author
                {
                    AuthorId = author.AuthorId,
                    Author = author
                }).ToList()
            };

            await _bookRepository.AddAsync(book);

            return book;
        }


    }
}

