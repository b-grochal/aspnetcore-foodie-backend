using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Infrastructure.Database.Interfaces
{
    public interface IDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        void Dispose();
    }
}
