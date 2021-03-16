using Foodie.Identity.Models;
using Foodie.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Services.Implementations
{
    public class AuthService : IAuthService
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
