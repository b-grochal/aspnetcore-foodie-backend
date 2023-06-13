using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Repositories
{
    public class RefreshTokensRepository : IRefreshTokensRepository
    {
        protected readonly IdentityDbContext dbContext;

        public RefreshTokensRepository(IdentityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ApplicationUserRefreshToken> CreateAsync(ApplicationUserRefreshToken entity)
        {
            await dbContext.Set<ApplicationUserRefreshToken>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(ApplicationUserRefreshToken entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<ApplicationUserRefreshToken> GetByApplicationUserIdAsync(int applicationUserId)
        {
            return await dbContext.Set<ApplicationUserRefreshToken>()
                .FirstOrDefaultAsync(x => x.ApplicationUserId == applicationUserId);
        }
    }
}
