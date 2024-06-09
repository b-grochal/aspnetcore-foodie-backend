using Foodie.Common.Infrastructure.Database.UnitOfWork;

namespace Foode.Identity.Infrastructure.Database.UnitOfWork
{
    public class IdentityUnitOfWork : BaseUnitOfWork
    {
        public IdentityUnitOfWork(IdentityDbContext dbContext) : base(dbContext)
        {
        }
    }
}
