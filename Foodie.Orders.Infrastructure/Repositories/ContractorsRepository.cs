using Foodie.Orders.Application.Contracts.Infrastructure.Context;
using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.AggregatesModel.ContractorAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Repositories
{
    public class ContractorsRepository : IContractorsRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task<Contractor> CreateAsync(Contractor contractor)
        {
            throw new NotImplementedException();
        }

        public Task<Contractor> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Contractor contractor)
        {
            throw new NotImplementedException();
        }
    }
}
