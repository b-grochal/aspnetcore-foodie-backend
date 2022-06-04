using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Services
{
    internal class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AuthService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> AuthenticateUser(string email, string password)
        {
            var applicationUser = await userManager.FindByEmailAsync(email);
            var isPasswordValid = await userManager.CheckPasswordAsync(applicationUser, password);

            if (applicationUser != null && isPasswordValid)
            {
                return applicationUser;
            }

            return null;
        }
    }
}
