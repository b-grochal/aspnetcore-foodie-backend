using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Infrastructure.Database.Contexts.Interfaces
{
    public interface IDbContext
    {
        Task<int> CommitChangesAsync(string user, CancellationToken cancellationToken);

        void Dispose();
    }
}
