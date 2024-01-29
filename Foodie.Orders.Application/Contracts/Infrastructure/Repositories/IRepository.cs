using Foodie.Common.Domain.AggregateRoots;
using Foodie.Orders.Application.Contracts.Infrastructure.Context;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Repositories
{
    public interface IRepository<T> where T : AggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
