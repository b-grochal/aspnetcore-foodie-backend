using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Repositories
{
    public class ApplicationUserRolesRepository : IApplicationUserRolesRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUserRolesRepository(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> CreateApplicationUserRole(ApplicationUser applicationUser, string roleName)
        {
            return await userManager.AddToRoleAsync(applicationUser, roleName);
        }

        public async Task<string> GetApplicationUserRole(ApplicationUser applicationUser)
        {
            return (await userManager.GetRolesAsync(applicationUser)).First();
        }
    }
}
