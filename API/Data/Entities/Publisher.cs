using System.ComponentModel.DataAnnotations;

namespace API.Data.Entities
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        public string Country { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
