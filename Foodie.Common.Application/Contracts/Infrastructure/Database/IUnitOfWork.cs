using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Application.Contracts.Infrastructure.Database
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitChangesAsync(string handlerName, CancellationToken cancellationToken = default);

        Task<int> CommitChangesAsync(int applicationUserId, string applcationUserEmail, string handlerName, CancellationToken cancellationToken = default);
    }
}
