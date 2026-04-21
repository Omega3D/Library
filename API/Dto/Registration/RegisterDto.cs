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
        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid phone format")]
        [RegularExpression(@"^\+?[0-9\s\-\(\)]{7,15}$",
            ErrorMessage = "Phone must contain only digits, +, -, spaces, or brackets")]
        public string Phone { get; set; } = null!;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
}
