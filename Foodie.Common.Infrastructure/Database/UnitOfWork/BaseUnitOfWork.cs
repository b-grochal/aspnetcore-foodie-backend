using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Infrastructure.Database.Contexts.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Infrastructure.Database.UnitOfWork
{
    public class BaseUnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;

        public BaseUnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<int> CommitChangesAsync(
            int? applicationUserId = null, 
            string applcationUserEmail = null, 
            string handlerName = null, 
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.CommitChangesAsync(applicationUserId, applcationUserEmail, handlerName, cancellationToken);
        }
    }
}
