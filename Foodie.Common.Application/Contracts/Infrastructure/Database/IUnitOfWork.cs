using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Application.Contracts.Infrastructure.Database
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitChangesAsync(string user, CancellationToken cancellationToken = default);
    }
}
