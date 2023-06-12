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
        private readonly JwtTokenConfiguration jwtTokenConfiguration;

        public RefreshTokenService(IOptions<JwtTokenConfiguration> jwtTokenConfigurationOptions)
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

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenConfiguration.Secret)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            
            return principal;
        }
    }
}
