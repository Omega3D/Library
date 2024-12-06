using API.Data.Entities;
using API.Dto.Request;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BooksAdminController : BaseContoller
    {
        private readonly IBooksAdminService _booksAdminService;

        public BooksAdminController(IBooksAdminService booksAdminService)
        {
            _booksAdminService = booksAdminService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
           var books = await _booksAdminService.GetBooksAsync();

            return Ok(books);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _booksAdminService.GetBookById(id);

            if(book == null) return NotFound("Book not found");
            
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook([FromBody] BookCreateDto bookDto)
        {
            var book = new Book()
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                Language = bookDto.Language,
                ISBN = bookDto.ISBN,
                Genre = bookDto.Genre,
                Type = bookDto.Type,
                PublicationYear = bookDto.PublicationYear,
                Price = bookDto.Price,
                Quantity = bookDto.Quantity,
                ImagePath = bookDto.ImagePath,
                PublisherId = bookDto.PublisherId,
            };

            await _booksAdminService.CreateBook(book);

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] BookCreateDto bookDto)
        {
            var existingBook = await _booksAdminService.GetBookById(id);

            if(existingBook == null) return NotFound("No book found");

            existingBook.Title = bookDto.Title;
            existingBook.Description = bookDto.Description;
            existingBook.Language = bookDto.Language;
            existingBook.ISBN = bookDto.ISBN;
            existingBook.Genre = bookDto.Genre;
            existingBook.Type = bookDto.Type;
            existingBook.PublicationYear = bookDto.PublicationYear;
            existingBook.Price = bookDto.Price;
            existingBook.Quantity = bookDto.Quantity;
            existingBook.ImagePath = bookDto.ImagePath;
            existingBook.PublisherId = bookDto.PublisherId;

            await _booksAdminService.UpdateBook(existingBook);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _booksAdminService.GetBookById(id);

            if (book == null) return NotFound("Book is not found");

            await _booksAdminService.DeleteBook(book);

            return NoContent();
        }
    }
}
