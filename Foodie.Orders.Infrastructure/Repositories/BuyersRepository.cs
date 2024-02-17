using Foodie.Orders.Application.Contracts.Infrastructure.Context;
using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Buyers;
using Foodie.Orders.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Repositories
{
    public class BuyersRepository : IBuyersRepository
    {
        private readonly OrdersDbContext _ordersDbContext;
        public IUnitOfWork UnitOfWork => _ordersDbContext;

        public BuyersRepository(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
        }

        public Buyer Create(Buyer buyer)
        {
            return _ordersDbContext.Buyers.Add(buyer).Entity;
        }

        public Buyer Update(Buyer buyer)
        {
            //_ordersDbContext.Entry(buyer).State = EntityState.Modified;
            return _ordersDbContext.Buyers.Update(buyer).Entity;
        }

        public async Task<Buyer> GetByIdAsync(int id)
        {
            return await _ordersDbContext.Buyers.FindAsync(id);
        }

        //TODO: Change customerId from int to string
        public async Task<Buyer> GetByCustomerIdAsync(string customerId)
        {
            return await _ordersDbContext.Buyers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
        }
    }
}
