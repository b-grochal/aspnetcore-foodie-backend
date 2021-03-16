using Foodie.Identity.Models;
using Foodie.Identity.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Repositories.Implementations
{
    public class ApplicationUserRolesRepository : IApplicationUserRolesRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUserRolesRepository(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<string> GetApplicationUserRole(string id)
        {
            var applicationUser = await userManager.FindByIdAsync(id);
            var applicationUsersRoles = await userManager.GetRolesAsync(applicationUser);
            return applicationUsersRoles.First();
        }
    }
}
