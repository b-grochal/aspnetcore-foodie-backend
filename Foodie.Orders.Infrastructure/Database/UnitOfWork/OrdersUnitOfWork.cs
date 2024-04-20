using Foodie.Common.Infrastructure.Database;

namespace Foodie.Orders.Infrastructure.Database.UnitOfWork
{
    public class OrdersUnitOfWork : BaseUnitOfWork
    {
        public OrdersUnitOfWork(OrdersDbContext dbContext) : base(dbContext)
        {
        }
    }
}
