using Foodie.Orders.Domain.AggregatesModel.ContractorAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Repositories
{
    public interface IContractorsRepository : IRepository<Contractor>
    {
        Contractor Create(Contractor contractor);
        Contractor Update(Contractor contractor);
        Task<Contractor> GetByIdAsync(int id);
        Task<Contractor> GetByRestaurantIdAsync(int restaurantId);
    }
}
