using API.Data;
using API.Dto;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BooksService : IBooksService
    {
        private readonly ApplicationDbContext _context;
        public BooksService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<BookSummaryDto>> GetBookSummariesAsync()
        {
            var books = await _context.Books
                .Select(b => new BookSummaryDto
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    Genre = b.Genre,
                    Price = b.Price,
                }).ToListAsync();

            return books;
        }

        public async Task<BookDetailDto?> GetBookDetailAsync(int bookId)
        {
            return await _context.Books
            .Where(b => b.BookId == bookId)
            .Select(b => new BookDetailDto
            {
                BookId = b.BookId,
                Title = b.Title,
                Description = b.Description,
                ISBN = b.ISBN,
                Genre = b.Genre,
                Type = b.Type,
                PublicationYear = b.PublicationYear,
                Price = b.Price,
                Quantity = b.Quantity,
                ImagePath = b.ImagePath
            }).FirstOrDefaultAsync();
        }
    }
}
