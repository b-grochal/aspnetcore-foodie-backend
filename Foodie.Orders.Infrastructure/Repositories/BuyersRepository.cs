using Foodie.Orders.Application.Contracts.Infrastructure.Context;
using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.AggregatesModel.BuyerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Repositories
{
    public class BuyersRepository : IBuyersRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task<Buyer> CreateAsync(Buyer buyer)
        {
            throw new NotImplementedException();
        }

        public Task<Buyer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Buyer buyer)
        {
            throw new NotImplementedException();
        }
    }
}
