using Foodie.Orders.Application.Contracts.Infrastructure.Context;
using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.AggregatesModel.ContractorAggregate;
using Foodie.Orders.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Repositories
{
    public class ContractorsRepository : IContractorsRepository
    {
        private readonly OrdersDbContext _ordersDbContext;
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public ContractorsRepository(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
        }

        public Contractor Create(Contractor contractor)
        {
            return _ordersDbContext.Contractors.Add(contractor).Entity;
        }

        public void Update(Contractor contractor)
        {
            _ordersDbContext.Entry(contractor).State = EntityState.Modified;
        }

        public Task<Contractor> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
