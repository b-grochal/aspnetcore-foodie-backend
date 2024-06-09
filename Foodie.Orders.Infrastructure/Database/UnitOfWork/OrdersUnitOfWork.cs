using Foodie.Common.Infrastructure.Database.UnitOfWork;

namespace Foodie.Orders.Infrastructure.Database.UnitOfWork
{
    public class OrdersUnitOfWork : BaseUnitOfWork
    {
        public OrdersUnitOfWork(OrdersDbContext dbContext) : base(dbContext)
        {
        }
    }
}
