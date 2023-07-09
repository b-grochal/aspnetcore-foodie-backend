using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Shared.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
