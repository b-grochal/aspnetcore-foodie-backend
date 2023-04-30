using EasyCaching.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Shared.Cache
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key) where T : class;
        Task<T> GetAsync<T>(string key, Func<Task<T>> factory) where T : class;
        Task SetAsync<T>(string key, T value) where T : class;
        Task RemoveAsync(string key);
        Task RemoveByPrefixAsync(CachePrefixes cachePrefixe);
    }

    public class CacheService : ICacheService
    {
        private readonly IEasyCachingProvider cachingProvider;
        private readonly ICacheKeyGenerator cacheKeyGenerator;
        private readonly TimeSpan expirationTime;

        public CacheService(IEasyCachingProvider cachingProvider, ICacheKeyGenerator cacheKeyGenerator)
        {
            this.cachingProvider = cachingProvider;
            this.cacheKeyGenerator = cacheKeyGenerator;
            this.expirationTime = TimeSpan.FromMinutes(30);
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            return (await cachingProvider.GetAsync<T>(key)).Value;
        }

        public async Task<T> GetAsync<T>(string key, Func<Task<T>> factory) where T : class
        {
            var cachedValue = await GetAsync<T>(key);

            if(cachedValue is not null)
                return cachedValue;

            cachedValue = await factory();
            
            await SetAsync(key, cachedValue);

            return cachedValue;
        }

        public async Task RemoveAsync(string key)
        {
            await cachingProvider.RemoveAsync(key);
        }

        public async Task RemoveByPrefixAsync(CachePrefixes cachePrefix)
        {
            await cachingProvider.RemoveByPrefixAsync(cachePrefix.ToString());
        }

        public async Task SetAsync<T>(string key, T value) where T : class
        {
            await cachingProvider.SetAsync<T>(key, value, expirationTime);
        }
    }
}
