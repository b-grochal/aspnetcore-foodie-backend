﻿using Foodie.Common.Collections;
using Foodie.Common.Infrastructure.Cache;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Domain.OrderHandlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Database.Repositories
{
    public class CachedOrderHandlersRepository : IOrderHandlersRepository
    {
        private readonly IOrderHandlersRepository decoratedRepository;
        private readonly ICacheService cacheService;

        public CachedOrderHandlersRepository(IOrderHandlersRepository orderHandlersRepository, ICacheService cacheService)
        {
            this.decoratedRepository = orderHandlersRepository;
            this.cacheService = cacheService;
        }

        public async Task<OrderHandler> CreateAsync(OrderHandler entity)
        {
            var result = await decoratedRepository.CreateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.OrderHandlers);
            return result;
        }

        public async Task DeleteAsync(OrderHandler entity)
        {
            await decoratedRepository.DeleteAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.OrderHandlers);
        }

        public async Task<PagedList<OrderHandler>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync(pageNumber, pageSize, email);
            }, CachePrefixes.OrderHandlers, parameters: new string[] { nameof(pageNumber), pageNumber.ToString(), nameof(pageSize), pageSize.ToString(), nameof(email), email });
        }

        public async Task<IReadOnlyList<OrderHandler>> GetAllAsync()
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync();
            }, CachePrefixes.OrderHandlers);
        }

        public async Task<OrderHandler> GetByIdAsync(int id)
        {
            return await decoratedRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(OrderHandler entity)
        {
            await decoratedRepository.UpdateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.OrderHandlers);
        }
    }
}
