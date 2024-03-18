using Foodie.Common.Collections;
using Foodie.Common.Infrastructure.Cache;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Admins;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Database.Repositories
{
    public class CachedAdminsRepository : IAdminsRepository
    {
        private readonly IAdminsRepository decoratedRepository;
        private readonly ICacheService cacheService;

        public CachedAdminsRepository(IAdminsRepository adminsRepository, ICacheService cacheService)
        {
            this.decoratedRepository = adminsRepository;
            this.cacheService = cacheService;
        }

        public async Task<Admin> CreateAsync(Admin entity)
        {
            var result = await decoratedRepository.CreateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Admins);
            return result;
        }

        public async Task DeleteAsync(Admin entity)
        {
            await decoratedRepository.DeleteAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Admins);
        }

        public async Task<PagedList<Admin>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync(pageNumber, pageSize, email);
            }, CachePrefixes.Admins, parameters: new string[] { nameof(pageNumber), pageNumber.ToString(), nameof(pageSize), pageSize.ToString(), nameof(email), email });
        }

        public async Task<IReadOnlyList<Admin>> GetAllAsync()
        {
            return await cacheService.GetAsync(async () =>
            {
                return await decoratedRepository.GetAllAsync();
            }, CachePrefixes.Admins);
        }

        public async Task<Admin> GetByIdAsync(int id)
        {
            return await decoratedRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Admin entity)
        {
            await decoratedRepository.UpdateAsync(entity);
            await cacheService.RemoveByPrefixAsync(CachePrefixes.Admins);
        }
    }
}
