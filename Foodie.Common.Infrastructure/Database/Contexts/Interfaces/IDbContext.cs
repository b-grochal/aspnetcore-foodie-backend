using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Infrastructure.Database.Contexts.Interfaces
{
    public interface IDbContext
    {
        Task<int> CommitChangesAsync(int applicationuserId, string applicationUserEmail, string handlerName, CancellationToken cancellationToken);

        Task<int> CommitChangesAsync(string handlerName, CancellationToken cancellationToken);

        void Dispose();
    }
}
