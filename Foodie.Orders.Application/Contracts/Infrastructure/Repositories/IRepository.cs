using Foodie.Common.Domain.AggregateRoots;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Repositories
{
    public interface IRepository<T> where T : AggregateRoot
    {
    }
}
