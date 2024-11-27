using System.ComponentModel.DataAnnotations;

namespace API.Data.Entities
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public string Role { get; set; } = "Customer";

        public Customer? Customer { get; set; }
    }
}
