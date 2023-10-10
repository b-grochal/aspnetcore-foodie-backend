using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Cache;
using Foodie.Shared.Types.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Repositories
{
    public class CachedRestaurantsRepository : IRestaurantsRepository
    {
        private readonly IRestaurantsRepository decoratedRepository;
        private readonly ICacheService cacheService;

        public CachedRestaurantsRepository(IRestaurantsRepository decoratedRepository, ICacheService cacheService)
        {
            this.decoratedRepository = decoratedRepository;
            this.cacheService = cacheService;
        }

        public async Task<Restaurant> CreateAsync(Restaurant entity)
        {
            var result = await decoratedRepository.CreateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Restaurants);
            return result;
        }

        public async Task DeleteAsync(Restaurant entity)
        {
            await decoratedRepository.DeleteAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Restaurants);
        }

        public async Task<PagedResult<Restaurant>> GetAllAsync(int pageNumber, int pageSize, int? categoryId, string name, string cityName)
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync(pageNumber, pageSize, categoryId, name, cityName);
            }, CachePrefixes.Restaurants, parameters: new string[] { nameof(pageNumber), pageNumber.ToString(), nameof(pageSize), pageSize.ToString(), nameof(categoryId), categoryId.ToString(), nameof(name), name, nameof(cityName), cityName });
        }

        public async Task<IReadOnlyList<Restaurant>> GetAllAsync()
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync();
            }, CachePrefixes.Restaurants);
        }

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            return await decoratedRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Restaurant entity)
        {
            await decoratedRepository.UpdateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Restaurants);
        }
    }
}
