using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Repositories
{
    public class BaseApplicationsUsersRepository<T> : IBaseApplicationUsersRepository<T> where T : ApplicationUser
    {
        protected readonly UserManager<ApplicationUser> userManager;
        protected readonly IdentityDbContext identityDbContext;

        public BaseApplicationsUsersRepository(UserManager<ApplicationUser> userManager, IdentityDbContext identityDbContext)
        {
            this.userManager = userManager;
            this.identityDbContext = identityDbContext;
        }

        public async Task CreateAsync(T applicationUser, string password)
        {
            await userManager.CreateAsync(applicationUser, password);
        }

        public async Task DeleteAsync(T applicationUser)
        {
            await userManager.DeleteAsync(applicationUser);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await identityDbContext.Set<T>().ToListAsync();
        }

        public async Task<PagedList<T>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            var applicationUsers = identityDbContext.Set<T>()
                .Where(c => email == null || c.Email.Equals(email));

            return PagedList<T>.ToPagedList(applicationUsers, pageNumber, pageSize);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await identityDbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T applicationUser)
        {
            await userManager.UpdateAsync(applicationUser);
        }
    }
}
