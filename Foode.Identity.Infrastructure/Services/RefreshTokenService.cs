using Foodie.Common.Infrastructure.Authentication;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;

namespace Foode.Identity.Infrastructure.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly JwtTokenSettings jwtTokenConfiguration;

        public RefreshTokenService(IOptions<JwtTokenSettings> jwtTokenConfigurationOptions)
        {
            this.jwtTokenConfiguration = jwtTokenConfigurationOptions.Value;
        }

        public (string RefreshToken, DateTimeOffset ExpirationDate) GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return (Convert.ToBase64String(randomNumber), DateTimeOffset.Now.AddMinutes(jwtTokenConfiguration.RefreshTokenExpiration));
        }
    }
}
