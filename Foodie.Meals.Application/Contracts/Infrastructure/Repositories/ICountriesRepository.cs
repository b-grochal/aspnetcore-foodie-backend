using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Repositories;
using Foodie.Shared.Types.Pagination;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface ICountriesRepository : IAsyncRepository<Country>
    {
        Task<PagedResult<Country>> GetAllAsync(int pageNumber, int pageSize, string name);
    }
}
