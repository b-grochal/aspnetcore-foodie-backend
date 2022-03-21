using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Extensions;
using Foodie.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface IRestaurantsRepository : IAsyncRepository<Restaurant>
    {
        PagedList<Restaurant> GetAllAsync(int pageNumber, int pageSize, int? categoryId, string name, string cityName);
    }
}
