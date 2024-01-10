using Foodie.Common.Application.Contracts.Infrastructure.Repositories.Interfaces;
using Foodie.Meals.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface ICitiesRepository : IRepository<City>
    {
        Task<IEnumerable<City>> GetAllAsync(int pageNumber, int pageSize, string name, int? countryId);
    }
}
