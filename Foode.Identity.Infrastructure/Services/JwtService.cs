using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Entities;
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

        public string GenerateToken(ApplicationUser applicationUser, string applicationUserRole)
        {
            var expirationTime = DateTime.Now.AddMinutes(jwtTokenConfiguration.AccessTokenExpiration);
            var identityClaims = CreateIdentityClaims(applicationUser, applicationUserRole);
            var signingCredentials = CreateSigningCredentials();

            var token = CreateJwtToken(identityClaims, signingCredentials, expirationTime);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private IEnumerable<Claim> CreateIdentityClaims(ApplicationUser applicationUser, string applicationUserRole)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, applicationUser.Id),
                new Claim(ClaimTypes.Name, applicationUser.UserName),
                new Claim(ClaimTypes.Email, applicationUser.Email),
                new Claim(ClaimTypes.Role, applicationUserRole),
                new Claim("Role", applicationUserRole)
            };
        }

        private IEnumerable<Claim> CreateApplicationUserClaims(ApplicationUser applicationUser)
        {
            return applicationUser switch
            {
                Admin admin => new List<Claim>
                {
                    new Claim("Admin", "Admin")
                },
                OrderHandler orderHandler => new List<Claim>
                {
                    new Claim("OrderHandler", "OrderHandler")
                },
                Customer customer => new List<Claim>
                {
                    new Claim("Customer", "Customer")
                },
                _ => throw new NotImplementedException(),
            };
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
