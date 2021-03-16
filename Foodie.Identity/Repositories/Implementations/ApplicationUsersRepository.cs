using Foodie.Identity.Models;
using Foodie.Identity.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Repositories.Implementations
{
    public class ApplicationUsersRepository : IApplicationUsersRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUsersRepository(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task CreateApplicationUser(ApplicationUser applicationUser, string applicationUserRole)
        {
            await userManager.CreateAsync(applicationUser);
            await userManager.AddToRoleAsync(applicationUser, applicationUserRole);
        }

        public async Task DeleteApplicationUser(string id)
        {
            var applicationUser = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(applicationUser);
        }

        public async Task EditApplicationUser(ApplicationUser applicationUser)
        {
            await userManager.UpdateAsync(applicationUser);
        }

        public async Task<ApplicationUser> GetApplicationUser(string id)
        {
            return await userManager.FindByIdAsync(id);
        }

        public async Task<IEnumerable<ApplicationUser>> GetApplicationUsers(string applicationUserRole)
        {
            return await userManager.GetUsersInRoleAsync(applicationUserRole);
        }
    }
}
