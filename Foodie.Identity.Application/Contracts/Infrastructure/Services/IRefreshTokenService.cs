using System;
using System.Security.Claims;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Services
{
    public interface IRefreshTokenService
    {
        (string RefreshToken, DateTimeOffset ExpirationDate) GenerateRefreshToken();
    }
}
