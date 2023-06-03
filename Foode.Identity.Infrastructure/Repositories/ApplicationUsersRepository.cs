using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Repositories
{
    public class ApplicationUsersRepository : IApplicationUsersRepository
    {
        private readonly IdentityDbContext dbContext;

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            return await dbContext.ApplicationUsers
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task UpdateAsync(ApplicationUser entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
