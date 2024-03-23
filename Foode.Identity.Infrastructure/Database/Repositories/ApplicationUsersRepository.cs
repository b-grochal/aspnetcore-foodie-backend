using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Domain.Common.ApplicationUser;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Database.Repositories
{
    public class ApplicationUsersRepository : IApplicationUsersRepository
    {
        private readonly IdentityDbContext dbContext;

        public ApplicationUsersRepository(IdentityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            return await dbContext.ApplicationUsers
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<ApplicationUser> GetByIdAsync(int id)
        {
            return await dbContext.Set<ApplicationUser>()
                .FindAsync(id);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return await dbContext.Set<ApplicationUser>()
                .AnyAsync(x => x.Email == email);
        }

        public async Task UpdateAsync(ApplicationUser entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
