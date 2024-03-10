using Foodie.Identity.Domain.Common.ApplicationUser;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Services
{
    public interface IJwtService
    {
        string GenerateToken(ApplicationUser applicationUser);
        int GetApplicationUserIdFromExpiredToken(string token);
    }
}
