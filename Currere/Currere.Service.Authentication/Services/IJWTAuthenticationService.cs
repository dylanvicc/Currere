using Currere.Shared.Objects;
using System.Security.Claims;

namespace Currere.Service.Authentication.Services
{
    public interface IJWTAuthenticationService
    {
        string GenerateToken(User user);

        string GenerateRefreshToken();

        ClaimsIdentity GenerateClaims(User user);
    }
}
