using Foodie.Orders.Application.Contracts.Infrastructure.Context;
using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Orders;
using Foodie.Orders.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersDbContext _ordersDbContext;
        public IUnitOfWork UnitOfWork => _ordersDbContext;

        public OrdersRepository(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
        }

        public Order Create(Order order)
        {
            return _ordersDbContext.Orders.Add(order).Entity;
        }

        public void Update(Order order)
        {
            _ordersDbContext.Entry(order).State = EntityState.Modified;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await _ordersDbContext
                            .Orders
                            .Include(x => x.DeliveryAddress)
                            .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                order = _ordersDbContext
                            .Orders
                            .Local
                            .FirstOrDefault(o => o.Id == id);
            }

            if (order != null)
            {
                await _ordersDbContext.Entry(order)
                    .Collection(i => i.OrderItems).LoadAsync();
                await _ordersDbContext.Entry(order)
                    .Reference(i => i.OrderStatus).LoadAsync();
            }

            return order;
        }
    }
}
