using API.Data.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Services
{
    public class BooksAdminService : IBooksAdminService
    {
        private readonly IRepository<Book> _bookRepository;
        public BooksAdminService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Book> CreateBook(Book book)
        {
            if (book.Title == string.Empty && book.Title == null) throw new Exception("Title must be provided!");
            var newBook = await _bookRepository.AddAsync(book);

            return newBook;
        }

        public async Task DeleteBook(Book book)
        {
            await _bookRepository.DeleteAsync(book);
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if(book == null)
            {
                throw new Exception("Book not found"); 
            }

            return book;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            if (books == null) throw new Exception("There is no books!");

            return books;
        }

        public async Task UpdateBook(Book book)
        {
            await _bookRepository.UpdateAsync(book);
        }
    }
}
