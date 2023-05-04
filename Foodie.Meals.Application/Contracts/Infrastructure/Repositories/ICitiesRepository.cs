using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Repositories;
using Foodie.Shared.Types.Pagination;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface ICitiesRepository : IAsyncRepository<City>
    {
        Task<PagedResult<City>> GetAllAsync(int pageNumber, int pageSize, string name, string country);
    }
}
