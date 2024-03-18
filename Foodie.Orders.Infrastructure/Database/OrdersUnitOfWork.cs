using Foodie.Common.Infrastructure.Database;

namespace Foodie.Orders.Infrastructure.Database
{
    public class OrdersUnitOfWork : BaseUnitOfWork
    {
        public OrdersUnitOfWork(OrdersDbContext dbContext) : base(dbContext)
        {
        }
    }
}
