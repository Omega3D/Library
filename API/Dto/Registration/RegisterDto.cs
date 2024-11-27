using System.ComponentModel.DataAnnotations;

namespace API.Dto.Registration
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;

        public string? Username { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Phone { get; set; }
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
}
