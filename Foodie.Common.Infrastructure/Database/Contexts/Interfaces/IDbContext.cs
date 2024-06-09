using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Infrastructure.Database.Contexts.Interfaces
{
    public interface IDbContext
    {
        Task<int> CommitChangesAsync(
            int? applicationuserId = null, 
            string applicationUserEmail = null, 
            string handlerName = null, 
            CancellationToken cancellationToken = default);

        void Dispose();
    }
}
