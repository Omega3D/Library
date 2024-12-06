namespace API.Dto.Request
{
    public class AuthorsCreateDto
    {
        public ICollection<AuthorCreateDto> Authors { get; set; } = new List<AuthorCreateDto>();
    }
}
