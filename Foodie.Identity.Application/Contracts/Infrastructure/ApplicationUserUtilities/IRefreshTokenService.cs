using System;

namespace Foodie.Identity.Application.Contracts.Infrastructure.ApplicationUserUtilities
{
    public interface IRefreshTokenService
    {
        (string RefreshToken, DateTimeOffset ExpirationDate) GenerateRefreshToken();
    }
}
