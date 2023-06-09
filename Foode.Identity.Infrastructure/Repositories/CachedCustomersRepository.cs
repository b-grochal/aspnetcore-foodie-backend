using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Cache;
using Foodie.Shared.Types.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Repositories
{
    public class CachedCustomersRepository : ICustomersRepository
    {
        private readonly ICustomersRepository decoratedRepository;
        private readonly ICacheService cacheService;

        public CachedCustomersRepository(ICustomersRepository customersRepository, ICacheService cacheService)
        {
            this.decoratedRepository = customersRepository;
            this.cacheService = cacheService;
        }

        public async Task<Customer> CreateAsync(Customer entity)
        {
            var result = await decoratedRepository.CreateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Customers);
            return result;
        }

        public async Task DeleteAsync(Customer entity)
        {
            await decoratedRepository.DeleteAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Customers);
        }

        public async Task<PagedResult<Customer>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync(pageNumber, pageSize, email);
            }, CachePrefixes.Customers, parameters: new string[] { nameof(pageNumber), pageNumber.ToString(), nameof(pageSize), pageSize.ToString(), nameof(email), email });
        }

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync();
            }, CachePrefixes.Customers);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await decoratedRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Customer entity)
        {
            await decoratedRepository.UpdateAsync(entity);
            await cacheService.RemoveAsync(CachePrefixes.Customers);
        }
    }
}
