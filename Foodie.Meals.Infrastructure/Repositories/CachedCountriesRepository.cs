using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Cache;
using Foodie.Shared.Types.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Repositories
{
    public class CachedCountriesRepository : ICountriesRepository
    {
        private readonly ICountriesRepository decoratedRepository;
        private readonly ICacheService cacheService;

        public CachedCountriesRepository(ICountriesRepository decoratedRepository, ICacheService cacheService)
        {
            this.decoratedRepository = decoratedRepository;
            this.cacheService = cacheService;
        }

        public async Task<Country> CreateAsync(Country entity)
        {
            var result = await decoratedRepository.CreateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Countries);
            return result;
        }

        public async Task DeleteAsync(Country entity)
        {
            await decoratedRepository.DeleteAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Countries);
        }

        public async Task<PagedResult<Country>> GetAllAsync(int pageNumber, int pageSize, string name)
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync(pageNumber, pageSize, name);
            }, CachePrefixes.Countries, parameters: new string[] { nameof(pageNumber), pageNumber.ToString(), nameof(pageSize), pageSize.ToString(), nameof(name), name });
        }

        public async Task<IReadOnlyList<Country>> GetAllAsync()
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync();
            }, CachePrefixes.Countries);
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await decoratedRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Country entity)
        {
            await decoratedRepository.UpdateAsync(entity);
            await cacheService.RemoveAsync(CachePrefixes.Countries);
        }
    }
}
