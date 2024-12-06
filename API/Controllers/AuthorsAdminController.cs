using API.Data.Entities;
using API.Dto.Request;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AuthorsAdminController : BaseContoller
    {
        private readonly IAuthorsAdminService _authorsAdminService;

        public AuthorsAdminController(IAuthorsAdminService authorsAdminService)
        {
            _authorsAdminService = authorsAdminService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthors()
        {
            var authors = await _authorsAdminService.GetAuthorsAsync();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _authorsAdminService.GetAuthorById(id);

            if (author == null) return NotFound("Author not found");

            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> CreateAuthors([FromBody] AuthorsCreateDto authorsDto)
        {
            if (authorsDto.Authors == null || !authorsDto.Authors.Any())
            {
                return BadRequest("No authors provided");
            }

            var authors = authorsDto.Authors.Select(dto => new Author
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            }).ToList();

            var createdAuthors = await _authorsAdminService.CreateAuthors(authors);

            return Ok(createdAuthors);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(int id, [FromBody] AuthorCreateDto authorDto)
        {
            var existingAuthor = await _authorsAdminService.GetAuthorById(id);

            if (existingAuthor == null) return NotFound("Author not found");

            existingAuthor.FirstName = authorDto.FirstName;
            existingAuthor.LastName = authorDto.LastName;

            await _authorsAdminService.UpdateAuthor(existingAuthor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _authorsAdminService.GetAuthorById(id);

            if (author == null) return NotFound("Author not found");

            await _authorsAdminService.DeleteAuthor(author);

            return NoContent();
        }
    }
}
