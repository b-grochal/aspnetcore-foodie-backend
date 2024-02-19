using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.Contractors;
using Foodie.Orders.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Repositories
{
    public class ContractorsRepository : IContractorsRepository
    {
        private readonly OrdersDbContext _ordersDbContext;

        public ContractorsRepository(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
        }

        public Contractor Create(Contractor contractor)
        {
            return _ordersDbContext.Contractors.Add(contractor).Entity;
        }

        public Contractor Update(Contractor contractor)
        {
            //_ordersDbContext.Entry(contractor).State = EntityState.Modified;
            return _ordersDbContext.Contractors.Update(contractor).Entity;
        }

        public async Task<Contractor> GetByIdAsync(int id)
        {
            return await _ordersDbContext.Contractors.FindAsync(id);
        }

        public async Task<Contractor> GetByParametersAsync(int restaurantId, int locationId, int cityId)
        {
            return await _ordersDbContext.Contractors.FirstOrDefaultAsync(x => x.RestaurantId == restaurantId && x.LocationId == locationId && x.CityId == cityId);
        }
    }
}
