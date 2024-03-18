using Foodie.Common.Infrastructure.Database;

namespace Foode.Identity.Infrastructure.Database.UnitOfWork
{
    public class IdentityUnitOfWork : BaseUnitOfWork
    {
        public IdentityUnitOfWork(IdentityDbContext dbContext) : base(dbContext)
        {
        }
    }
}
