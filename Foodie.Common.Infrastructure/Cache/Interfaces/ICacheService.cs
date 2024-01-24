using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Foodie.Common.Infrastructure.Cache.Interfaces
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(CachePrefixes cachePrefix, [CallerMemberName] string methodName = "", params string[] parameters) where T : class;
        Task<T> GetAsync<T>(Func<Task<T>> factory, CachePrefixes cachePrefix, [CallerMemberName] string methodName = "", params string[] parameters) where T : class;
        Task SetAsync<T>(T value, CachePrefixes cachePrefix, [CallerMemberName] string methodName = "", params string[] parameters) where T : class;
        Task RemoveAsync(CachePrefixes cachePrefix, [CallerMemberName] string methodName = "", params string[] parameters);
        Task RemoveByPrefixAsync(CachePrefixes cachePrefixe);
    }
}
