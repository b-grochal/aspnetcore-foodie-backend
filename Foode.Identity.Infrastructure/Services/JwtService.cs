using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Authentication;
using Foodie.Shared.Enums;
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
        private readonly JwtTokenConfiguration jwtTokenConfiguration;

        public JwtService(IOptions<JwtTokenConfiguration> jwtTokenConfigurationOptions)
        {
            this.jwtTokenConfiguration = jwtTokenConfigurationOptions.Value;
        }

        public string GenerateToken(ApplicationUser applicationUser, string applicationUserRole)
        {
            var expirationTime = DateTime.Now.AddMinutes(jwtTokenConfiguration.AccessTokenExpiration);
            var identityClaims = CreateIdentityClaims(applicationUser, applicationUserRole);
            identityClaims.AddRange(CreateApplicationUserClaims(applicationUser, applicationUserRole));
            var signingCredentials = CreateSigningCredentials();

            var token = CreateJwtToken(identityClaims, signingCredentials, expirationTime);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private List<Claim> CreateIdentityClaims(ApplicationUser applicationUser, string applicationUserRole)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, applicationUser.Id),
                new Claim(ClaimTypes.Name, applicationUser.UserName),
                new Claim(ClaimTypes.Email, applicationUser.Email),
                new Claim(ClaimTypes.Role, applicationUserRole)
            };
        }

        private IEnumerable<Claim> CreateApplicationUserClaims(ApplicationUser applicationUser, string applicationUserRole)
        {
            var applicationUserClaims = new List<Claim>
            {
                new Claim(ApplicationUserClaims.Role, applicationUserRole)
            };

            if (applicationUser is OrderHandler orderHandler)
            {
                applicationUserClaims.Add(new Claim(ApplicationUserClaims.LocationId, orderHandler.LocationId.ToString()));
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
