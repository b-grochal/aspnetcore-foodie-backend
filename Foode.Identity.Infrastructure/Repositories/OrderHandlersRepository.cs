﻿using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IdentityDbContext identityDbContext;

        public OrderHandlersRepository(UserManager<ApplicationUser> userManager, IdentityDbContext identityDbContext)
        {
            this.userManager = userManager;
            this.identityDbContext = identityDbContext;
        }

        public async Task CreateAsync(OrderHandler orderHandler, string password)
        {
            await userManager.CreateAsync(orderHandler, password);
            await userManager.AddToRoleAsync(orderHandler, ApplicationUserRoles.OrderHandler);
            await identityDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrderHandler orderHandler)
        {
            await userManager.DeleteAsync(orderHandler);
            await identityDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<OrderHandler>> GetAllAsync()
        {
            return await identityDbContext.OrderHandlers.ToListAsync();
        }

        public async Task<PagedList<OrderHandler>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            var orderHandlers = identityDbContext.OrderHandlers
                .Where(c => email == null || c.Email.Equals(email));

            return PagedList<OrderHandler>.ToPagedList(orderHandlers, pageNumber, pageSize);
        }

        public async Task<OrderHandler> GetByIdAsync(string id)
        {
            return await identityDbContext.OrderHandlers.FindAsync(id);
        }

        public async Task UpdateAsync(OrderHandler orderHandler)
        {
            await userManager.UpdateAsync(orderHandler);
            await identityDbContext.SaveChangesAsync();
        }
    }
}
