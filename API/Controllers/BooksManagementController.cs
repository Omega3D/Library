using API.Data.Entities;
using API.Dto.Request;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BooksManagementController : BaseContoller
    {
        private readonly IBooksManagementService _booksManagementService;
        public BooksManagementController(IBooksManagementService booksManagementService)
        {
            _booksManagementService = booksManagementService;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(CreateBookWithDetailsDto dto)
        {
            return await _booksManagementService.CreateBookWithDetails(dto);
        }
    }
}
