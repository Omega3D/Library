using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [RegularExpression(@"^\+?[0-9\s\-\(\)]{7,15}$", ErrorMessage = "Phone must contain only digits, +, -, spaces, or brackets")]
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;

        [ForeignKey("AppUser")]
        public int UserId { get; set; }
        public AppUser User { get; set; } = null!;
    }
}
