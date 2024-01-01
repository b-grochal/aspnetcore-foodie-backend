using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Cache;
using Foodie.Shared.Types.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Repositories
{
    public class CachedMealsRepository : IMealsRepository
    {
        private readonly IMealsRepository decoratedRepository;
        private readonly ICacheService cacheService;

        public CachedMealsRepository(IMealsRepository decoratedRepository, ICacheService cacheService)
        {
            this.decoratedRepository = decoratedRepository;
            this.cacheService = cacheService;
        }

        public async Task<Meal> CreateAsync(Meal entity)
        {
            var result = await decoratedRepository.CreateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Meals);
            return result;
        }

        public async Task DeleteAsync(Meal entity)
        {
            await decoratedRepository.DeleteAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Meals);
        }

        public async Task<IReadOnlyList<Meal>> GetAllAsync(int restaurantId)
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync(restaurantId);
            }, CachePrefixes.Meals, parameters: new string[] { nameof(restaurantId), restaurantId.ToString() });
        }

        public async Task<PagedResult<Meal>> GetAllAsync(int pageNumber, int pageSize, int? restaurantId, string name)
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync(pageNumber, pageSize, restaurantId, name);
            }, CachePrefixes.Meals, parameters: new string[] { nameof(pageNumber), pageNumber.ToString(), nameof(pageSize), pageSize.ToString(), nameof(restaurantId), restaurantId.ToString(), nameof(name), name });
        }

        public async Task<IReadOnlyList<Meal>> GetAllAsync()
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync();
            }, CachePrefixes.Meals);
        }

        public async Task<Meal> GetByIdAsync(int id)
        {
            return await decoratedRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Meal entity)
        {
            await decoratedRepository.UpdateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Meals);
        }
    }
}
