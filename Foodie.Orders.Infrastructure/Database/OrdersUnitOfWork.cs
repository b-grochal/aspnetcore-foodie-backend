using Foodie.Common.Infrastructure.Database;

namespace Foodie.Orders.Infrastructure.Database
{
    public class OrdersUnitOfWork : UnitOfWork
    {
        public OrdersUnitOfWork(OrdersDbContext dbContext) : base(dbContext)
        {
        }
    }
}
