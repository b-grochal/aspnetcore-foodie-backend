using Foodie.Meals.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface ICitiesRepository
    {
        Task CreateCity(City city);
        Task DeleteCity(int cityId);
        Task UpdateCity(City city);
        Task<City> GetCity(int cityId);
        Task<IEnumerable<City>> GetCities();
    }
}
