using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Repositories
{
    public class OrderHandlersRepository : IOrderHandlersRepository
    {
        private readonly UserManager<Admin> userManager;
        private readonly IdentityDbContext identityDbContext;

        public OrderHandlersRepository(UserManager<Admin> userManager, IdentityDbContext identityDbContext)
        {
            this.userManager = userManager;
            this.identityDbContext = identityDbContext;
        }

        public async Task CreateAsync(Admin orderHandler)
        {
            await userManager.CreateAsync(orderHandler);
            await userManager.AddToRoleAsync(orderHandler, ApplicationUserRoles.OrderHandler);
        }

        public async Task DeleteAsync(Admin orderHandler)
        {
            await userManager.DeleteAsync(orderHandler);
        }

        public async Task<IReadOnlyList<Admin>> GetAllAsync()
        {
            return await identityDbContext.OrderHandlers.ToListAsync();
        }

        public async Task<PagedList<Admin>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            var orderHandlers = identityDbContext.OrderHandlers
                .Where(c => email == null || c.Email.Equals(email));

            return PagedList<Admin>.ToPagedList(orderHandlers, pageNumber, pageSize);
        }

        public async Task<Admin> GetByIdAsync(string id)
        {
            return await identityDbContext.OrderHandlers.FindAsync(id);
        }

        public async Task UpdateAsync(Admin orderHandler)
        {
            await userManager.UpdateAsync(orderHandler);
        }
    }
}
