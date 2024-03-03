using Foodie.Common.Infrastructure.Database;

namespace Foode.Identity.Infrastructure.Database
{
    public class IdentityUnitOfWork : UnitOfWork
    {
        public IdentityUnitOfWork(IdentityDbContext dbContext) : base(dbContext)
        {
        }
    }
}
