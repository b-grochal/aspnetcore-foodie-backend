using Foodie.Common.Application.Contracts.Infrastructure.Repositories.Interfaces;
using Foodie.Common.Collections;
using Foodie.Meals.Domain.Entities;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface ICountriesRepository : IRepository<Country>
    {
        Task<PagedList<Country>> GetAllAsync(int pageNumber, int pageSize, string name);
    }
}
