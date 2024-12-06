using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Data.Entities
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        [JsonIgnore]
        public ICollection<Book_Author> Book_Authors { get; set; } = new List<Book_Author>();
    }
}
