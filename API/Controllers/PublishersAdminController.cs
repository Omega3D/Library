using API.Data.Entities;
using API.Dto.Request;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PublishersAdminController : BaseContoller
    {
        private readonly IPublishersAdminService _publishersAdminService;

        public PublishersAdminController(IPublishersAdminService publishersAdminService)
        {
            _publishersAdminService = publishersAdminService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetAllPublishers()
        {
            var publishers = await _publishersAdminService.GetPublishersAsync();

            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetPublisher(int id)
        {
            var publisher = await _publishersAdminService.GetPublisherByIdAsync(id);

            if (publisher == null) return NotFound("Book not found");

            return Ok(publisher);
        }

        [HttpPost]
        public async Task<ActionResult<Publisher>> CreatePublisher([FromBody] PublisherCreateDto publisherDto)
        {
            var publisher = new Publisher()
            {
                Name = publisherDto.Name
            };

            await _publishersAdminService.CreatePublisher(publisher);

            return Ok(publisher);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePublisher(int id, [FromBody] PublisherCreateDto publisherDto)
        {
            var existingPublisher = await _publishersAdminService.GetPublisherByIdAsync(id);

            if (existingPublisher == null) return NotFound("No publisher found");

            existingPublisher.Name = publisherDto.Name;

            await _publishersAdminService.UpdatePublisher(existingPublisher);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var publisher = await _publishersAdminService.GetPublisherByIdAsync(id);

            if (publisher == null) return NotFound("Publisher is not found");

            await _publishersAdminService.DeletePublisher(publisher);

            return NoContent();
        }
    }
}

