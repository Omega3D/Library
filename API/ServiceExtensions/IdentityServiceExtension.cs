using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.ServiceExtensions
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding
                            .UTF8.GetBytes(config["Jwt:Key"]!)),

                            // Add these back for better security
                            ValidateIssuer = true,
                            ValidIssuer = config["Jwt:Issuer"],
                            ValidateAudience = true,
                            ValidAudience = config["Jwt:Audience"],

                            // Ensure token hasn't expired
                            ValidateLifetime = true,

                            // Clock skew allows for slight time differences
                            ClockSkew = TimeSpan.FromMinutes(5)
                        };
                    });

            return services;
        }
    }
}
