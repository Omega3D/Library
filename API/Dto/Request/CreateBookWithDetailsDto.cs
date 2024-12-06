using System.ComponentModel.DataAnnotations;

namespace API.Dto.Request
{
    public class CreateBookWithDetailsDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Type {  get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public int PublisherId { get; set; }
        public List<int> AuthorIds { get; set; } = null!;      
        public bool ValidateAuthors()
        {
            return AuthorIds != null && AuthorIds.Count > 0 &&
                   AuthorIds.All(id => id > 0);
        }
    }
}
