using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Data.Entities
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
