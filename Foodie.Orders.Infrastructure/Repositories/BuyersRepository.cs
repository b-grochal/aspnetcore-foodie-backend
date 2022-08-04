using Foodie.Orders.Application.Contracts.Infrastructure.Context;
using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.AggregatesModel.BuyerAggregate;
using Foodie.Orders.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Repositories
{
    public class BuyersRepository : IBuyersRepository
    {
        private readonly OrdersDbContext _ordersDbContext;
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public BuyersRepository(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
        }

        public Buyer Create(Buyer buyer)
        {
            return _ordersDbContext.Buyers.Add(buyer).Entity;
        }

        public void Update(Buyer buyer)
        {
            _ordersDbContext.Entry(buyer).State = EntityState.Modified;
        }

        public Task<Buyer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
