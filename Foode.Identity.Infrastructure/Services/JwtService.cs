using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Shared.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Services
{
    internal class JwtService : IJwtService
    {
        private readonly JwtTokenConfiguration jwtTokenConfiguration;

        public JwtService(JwtTokenConfiguration jwtTokenConfiguration)
        {
            this.jwtTokenConfiguration = jwtTokenConfiguration;
        }

        public string GenerateToken(string applicationUserId, string applicationUserRole)
        {
            var authClaims = new[]
                {
                    new Claim("ApplicationUserId", applicationUserId),
                    new Claim(ClaimTypes.Role, applicationUserRole),
                    new Claim("Role", applicationUserRole)
                };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenConfiguration.Secret));

            var token = new JwtSecurityToken(
                issuer: jwtTokenConfiguration.Issuer,
                audience: jwtTokenConfiguration.Audience,
                expires: DateTime.Now.AddMinutes(jwtTokenConfiguration.AccessTokenExpiration),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
