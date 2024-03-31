using Foodie.Common.Domain.AggregateRoots;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories
{
    public interface IRepository<T> where T : AggregateRoot
    {
    }
}
