﻿using API.Dto;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BooksController : BaseContoller
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<BookSummaryDto>>> GetBooks()
        {
            var books = await _booksService.GetBookSummariesAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailDto>> GetBookDetail(int id)
        {
            var book = await _booksService.GetBookDetailAsync(id);

            if (book == null) return NotFound("No book found");
            
            return Ok(book);
        }
    }
}