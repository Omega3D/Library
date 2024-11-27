namespace API.Dto.Registration
{
    public class AuthResponseDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
