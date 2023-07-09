using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Foode.Identity.Infrastructure.Services
{
    internal class JwtService : IJwtService
    {
        private readonly JwtTokenSettings jwtTokenConfiguration;

        public JwtService(IOptions<JwtTokenSettings> jwtTokenConfigurationOptions)
        {
            this.jwtTokenConfiguration = jwtTokenConfigurationOptions.Value;
        }

        public string GenerateToken(ApplicationUser applicationUser)
        {
            var expirationTime = DateTime.Now.AddMinutes(jwtTokenConfiguration.AccessTokenExpiration);
            var applicationUserClaims = CreateApplicationUserClaims(applicationUser);
            var signingCredentials = CreateSigningCredentials();

            var token = CreateJwtToken(applicationUserClaims, signingCredentials, expirationTime);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public int GetApplicationUserIdFromExpiredToken(string token)
        {
            var applicationUserId = GetClaimsPrincipalFromExpiredToken(token)
                .FindFirstValue(ApplicationUserClaim.ApplicationUserId);

            if(applicationUserId is null)
                throw new SecurityTokenException("Invalid token");

            return int.Parse(applicationUserId);
        }

        private ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = jwtTokenConfiguration.Audience,
                ValidateIssuer = true,
                ValidIssuer = jwtTokenConfiguration.Issuer,
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

        private List<Claim> CreateApplicationUserClaims(ApplicationUser applicationUser)
        {
            var applicationUserClaims = new List<Claim>
            {
                new Claim(ApplicationUserClaim.ApplicationUserId, applicationUser.Id.ToString()),
                new Claim(ApplicationUserClaim.Email, applicationUser.Email),
                new Claim(ApplicationUserClaim.Role, applicationUser.Role.ToString())
            };

            if (applicationUser is OrderHandler orderHandler)
            {
                applicationUserClaims.Add(new Claim(ApplicationUserClaim.LocationId, orderHandler.LocationId.ToString()));
            }

            return applicationUserClaims;
        }

        private SigningCredentials CreateSigningCredentials()
        {
            return new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenConfiguration.Secret)), SecurityAlgorithms.HmacSha256);
        }

        private JwtSecurityToken CreateJwtToken(IEnumerable<Claim> claims, SigningCredentials signingCredentials, DateTime expirationTime)
        {
            return new JwtSecurityToken(issuer: jwtTokenConfiguration.Issuer,
                audience: jwtTokenConfiguration.Audience,
                expires: expirationTime,
                claims: claims,
                signingCredentials: signingCredentials);
        }
    }
}
