using Foodie.Identity.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Services.Implementations
{
    public class JwtService
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
                    new Claim("Role", applicationUserRole),
                    new Claim(ClaimTypes.Role, applicationUserRole)
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
