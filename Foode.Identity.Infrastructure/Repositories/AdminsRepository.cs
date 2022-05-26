using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Extensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Repositories
{
    public class AdminsRepository : IAdminsRepository
    {
        private readonly UserManager<Admin> userManager;
        private readonly

        public AdminsRepository(UserManager<Admin> userManager)
        {
            this.userManager = userManager;
        }

        public async Task CreateAsync(Admin admin)
        {
            await userManager.CreateAsync(admin);
            await userManager.AddToRoleAsync(admin, ApplicationUserRoles.Admin);
        }

        public async Task DeleteAsync(Admin admin)
        {
            await userManager.DeleteAsync(admin);
        }

        public async Task<IReadOnlyList<Admin>> GetAllAsync()
        {
            return (IReadOnlyList<Admin>)await userManager.GetUsersInRoleAsync(ApplicationUserRoles.Admin);
        }

        public async Task<PagedList<Admin>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            return (PagedList<Admin>)await userManager.GetUsersInRoleAsync(ApplicationUserRoles.Admin);
        }

        public async Task<Admin> GetByIdAsync(string id)
        {
            return await userManager.FindByIdAsync(id);
        }

        public async Task UpdateAsync(Admin admin)
        {
            await userManager.UpdateAsync(admin);
        }
    }
}
