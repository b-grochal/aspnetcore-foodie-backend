using Foodie.Common.Application.Contracts.Infrastructure.Repositories.Interfaces;
using Foodie.Common.Collections;
using Foodie.Meals.Domain.Entities;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories
{
    public interface IRestaurantsRepository : IGenericRepository<Restaurant>
    {
        Task<PagedList<Restaurant>> GetAllAsync(int pageNumber, int pageSize, int? categoryId, string name, string cityName);
    }
}
