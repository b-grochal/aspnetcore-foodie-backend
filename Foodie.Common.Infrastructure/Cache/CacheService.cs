using EasyCaching.Core;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Foodie.Common.Infrastructure.Cache
{
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

        public async Task<T> GetAsync<T>(CachePrefixes cachePrefix, [CallerMemberName] string methodName = "", params string[] parameters) where T : class
        {
            var key = cacheKeyGenerator.GenerateCacheKey(cachePrefix, methodName, parameters);
            return await GetAsync<T>(key);
        }

        public async Task<T> GetAsync<T>(Func<Task<T>> factory, CachePrefixes cachePrefix, [CallerMemberName] string methodName = "", params string[] parameters) where T : class
        {
            var key = cacheKeyGenerator.GenerateCacheKey(cachePrefix, methodName, parameters);
            var cachedValue = await GetAsync<T>(key);

            if(cachedValue is not null)
                return cachedValue;

            cachedValue = await factory();
            
            await SetAsync<T>(key, cachedValue);

            return cachedValue;
        }

        public async Task RemoveAsync(CachePrefixes cachePrefix, [CallerMemberName] string methodName = "", params string[] parameters)
        {
            var key = cacheKeyGenerator.GenerateCacheKey(cachePrefix, methodName, parameters);
            await cachingProvider.RemoveAsync(key);
        }

        public async Task RemoveByPrefixAsync(CachePrefixes cachePrefix)
        {
            await cachingProvider.RemoveByPrefixAsync(cachePrefix.ToString());
        }

        public async Task SetAsync<T>(T value, CachePrefixes cachePrefix, [CallerMemberName] string methodName = "", params string[] parameters) where T : class
        {
            var key = cacheKeyGenerator.GenerateCacheKey(cachePrefix, methodName, parameters);
            await SetAsync<T>(key, value);
        }

        private async Task<T> GetAsync<T>(string key)
        {
            return (await cachingProvider.GetAsync<T>(key)).Value;
        }

        private async Task SetAsync<T>(string key, T value)
        {
            await cachingProvider.SetAsync<T>(key, value, expirationTime);
        }
    }
}
