namespace Foodie.Common.Infrastructure.Cache.Interfaces
{
    public interface ICacheKeyGenerator
    {
        string GenerateCacheKey(CachePrefixes cachePrefix, string methodName, params string[] parameters);
    }
}
