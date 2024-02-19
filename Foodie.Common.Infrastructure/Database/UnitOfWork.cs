using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Infrastructure.Database.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
