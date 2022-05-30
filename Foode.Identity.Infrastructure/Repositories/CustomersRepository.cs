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
    public class CustomersRepository : ICustomersRepository
    {
        private readonly UserManager<Customer> userManager;
        private readonly IdentityDbContext identityDbContext;

        public CustomersRepository(UserManager<Customer> userManager, IdentityDbContext identityDbContext)
        {
            this.userManager = userManager;
            this.identityDbContext = identityDbContext;
        }

        public async Task CreateAsync(Customer customer)
        {
            await userManager.CreateAsync(customer);
            await userManager.AddToRoleAsync(customer, ApplicationUserRoles.Customer);
        }

        public async Task DeleteAsync(Customer customer)
        {
            await userManager.DeleteAsync(customer);
        }

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            return await identityDbContext.Customers.ToListAsync();
        }

        public async Task<PagedList<Customer>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            var customers = identityDbContext.Customers
                .Where(c => email == null || c.Email.Equals(email));

            return PagedList<Customer>.ToPagedList(customers, pageNumber, pageSize);
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            return await identityDbContext.Customers.FindAsync(id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            await userManager.UpdateAsync(customer);
        }
    }
}
