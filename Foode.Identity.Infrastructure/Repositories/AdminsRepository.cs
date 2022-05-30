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
    public class AdminsRepository : IAdminsRepository
    {
        private readonly UserManager<OrderHandler> userManager;
        private readonly IdentityDbContext identityDbContext;

        public AdminsRepository(UserManager<OrderHandler> userManager, IdentityDbContext identityDbContext)
        {
            this.userManager = userManager;
            this.identityDbContext = identityDbContext;
        }

        public async Task CreateAsync(OrderHandler admin)
        {
            await userManager.CreateAsync(admin);
            await userManager.AddToRoleAsync(admin, ApplicationUserRoles.Admin);
        }

        public async Task DeleteAsync(OrderHandler admin)
        {
            await userManager.DeleteAsync(admin);
        }

        public async Task<IReadOnlyList<OrderHandler>> GetAllAsync()
        {
            return await identityDbContext.Admins.ToListAsync();
        }

        public async Task<PagedList<OrderHandler>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            var admins = identityDbContext.Admins
                .Where(c => email == null || c.Email.Equals(email));

            return PagedList<OrderHandler>.ToPagedList(admins, pageNumber, pageSize);
        }

        public async Task<OrderHandler> GetByIdAsync(string id)
        {
            return await identityDbContext.Admins.FindAsync(id);
        }

        public async Task UpdateAsync(OrderHandler admin)
        {
            await userManager.UpdateAsync(admin);
        }
    }
}