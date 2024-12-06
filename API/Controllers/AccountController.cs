using API.Data;
using API.Data.Entities;
using API.Dto.Registration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    public class AccountController : BaseContoller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;


        public AccountController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto registerDto)
        {
            if (await _context.AppUsers.AnyAsync(u => u.EmailAddress == registerDto.EmailAddress))
                throw new Exception("Email already exists");

            string username = registerDto.Username ?? GenerateUniqueUsername(registerDto.EmailAddress);

            if(username == null || username == string.Empty) GenerateUniqueUsername(registerDto.EmailAddress);

            if (await _context.AppUsers.AnyAsync(u => u.Username == username))
                throw new Exception("Username already exists");

            CreatePasswordHash(registerDto.Password,
                out byte[] passwordHash,
                out byte[] passwordSalt);

            var appUser = new AppUser
            {
                Username = username!,
                EmailAddress = registerDto.EmailAddress,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "Customer"
            };

            var customer = new Customer
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Phone = registerDto.Phone,
                City = registerDto.City,
                PostalCode = registerDto.PostalCode,
                User = appUser
            };

            _context.AppUsers.Add(appUser);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(new AuthResponseDto
            {
                UserId = appUser.UserId,
                Username = appUser.Username,
                EmailAddress = appUser.EmailAddress,
                Token = CreateToken(appUser),
                Role = appUser.Role
            });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponseDto>> Login(LoginDto loginDto)
        {
            var user = await _context.AppUsers
                .FirstOrDefaultAsync(u => u.EmailAddress == loginDto.EmailAddress);

            if (user == null)
                throw new Exception("User not found");

            if (!VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Invalid password");

            return Ok(new AuthResponseDto
            {
                UserId = user.UserId,
                Username = user.Username,
                EmailAddress = user.EmailAddress,
                Token = CreateToken(user),
                Role = user.Role
            });
        }

        private string GenerateUniqueUsername(string email)
        {
            string baseUsername = email.Split('@')[0];

            string username = baseUsername;
            int suffix = 1;

            while (_context.AppUsers.Any(u => u.Username == username))
            {
                username = $"{baseUsername}{suffix}";
                suffix++;
            }

            return username;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(AppUser user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Jwt:Key").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
