using Currere.Shared.Objects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Currere.Service.Authentication.Services
{
    public class DefaultJWTAuthenticationService(IConfiguration configuration) : IJWTAuthenticationService
    {
        private readonly IConfiguration _configuration = configuration;

        public ClaimsIdentity GenerateClaims(User user)
        {
            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Email, user.EmailAddress));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName));
            identity.AddClaim(new Claim(ClaimTypes.PrimarySid, user.UserID.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.RoleID.ToString()));
            return identity;
        }

        public string GenerateRefreshToken()
        {
            var token = new byte[32];

            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(token);

            return Convert.ToBase64String(token);
        }

        public string GenerateToken(User user)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Authentication:Key") ?? string.Empty);

            if (key.Length == 0)
                return string.Empty;

            var descriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration.GetValue<string>("Authentication:Issuer") ?? string.Empty,
                Subject = GenerateClaims(user)
            };

            return handler.WriteToken(handler.CreateToken(descriptor));
        }
    }
}
