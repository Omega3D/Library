using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Genre {  get; set; } = string.Empty;
        public string Type {  get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; } = string.Empty;

        public ICollection<Author> Authors { get; set; } = new List<Author>();

        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
    }
}
