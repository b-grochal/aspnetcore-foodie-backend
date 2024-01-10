using Foodie.Common.Application.Contracts.Infrastructure.Repositories.Interfaces;
using Foodie.Meals.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface IRestaurantsRepository : IRepository<Restaurant>
    {
        Task<IEnumerable<Restaurant>> GetAllAsync(int pageNumber, int pageSize, int? categoryId, string name, string cityName);
    }
}
