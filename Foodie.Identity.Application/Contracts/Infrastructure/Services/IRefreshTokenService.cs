using System.Security.Claims;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Services
{
    public interface IRefreshTokenService
    {
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
