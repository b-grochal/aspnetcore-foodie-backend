﻿using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Cache;
using Foodie.Shared.Types.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Repositories
{
    public class CachedCitiesRepository : ICitiesRepository
    {
        private readonly ICitiesRepository decoratedRepository;
        private readonly ICacheService cacheService;

        public CachedCitiesRepository(ICitiesRepository citiesRepsitory, ICacheService cacheService)
        {
            this.decoratedRepository = citiesRepsitory;
            this.cacheService = cacheService;
        }

        public async Task<City> CreateAsync(City entity)
        {
            var result = await decoratedRepository.CreateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Cities);
            return result;
        }

        public async Task DeleteAsync(City entity)
        {
            await decoratedRepository.DeleteAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Cities);
        }

        public async Task<PagedResult<City>> GetAllAsync(int pageNumber, int pageSize, string name, int? countryId)
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync(pageNumber, pageSize, name, countryId);
            }, CachePrefixes.Cities, parameters: new string[] { nameof(pageNumber), pageNumber.ToString(), nameof(pageSize), pageSize.ToString(), nameof(name), name, nameof(countryId), countryId.ToString() });
        }

        public async Task<IReadOnlyList<City>> GetAllAsync()
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync();
            }, CachePrefixes.Cities);
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await decoratedRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(City entity)
        {
            await decoratedRepository.UpdateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Cities);
        }
    }
}
