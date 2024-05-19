using Foodie.Orders.Domain.Orders;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories
{
    public interface IOrdersRepository : IRepository<Order>
    {
        Order Create(Order order);
        void Update(Order order);
        Task<Order> GetByIdAsync(int id);
    }
}
