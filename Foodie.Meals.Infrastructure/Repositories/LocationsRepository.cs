using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Repositories
{
    public class LocationsRepository : BaseMealsRepository<Location>, ILocationsRepository
    {
        public LocationsRepository(MealsDbContext dbContext) : base(dbContext) { }

        public Task<PagedList<Location>> GetAllAsync(int pageNumber, int pageSize, int restaurantId, int cityId)
        {
            throw new NotImplementedException();
        }
    }
}
