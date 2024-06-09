using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Application.Contracts.Infrastructure.Database
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitChangesAsync(
            int? applicationUserId = null, 
            string applcationUserEmail = null, 
            string handlerName = null, 
            CancellationToken cancellationToken = default);
    }
}
