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

        public async Task<string> GetApplicationUserRole(string id)
        {
            var applicationUser = await userManager.FindByIdAsync(id);
            var applicationUsersRoles = await userManager.GetRolesAsync(applicationUser);
            return applicationUsersRoles.First();
        }
    }
}
