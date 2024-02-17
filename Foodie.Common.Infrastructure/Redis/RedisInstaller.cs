using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foodie.Shared.Redis
{
    public static class RedisInstaller
    {
        public static IServiceCollection AddRedis(this IServiceCollection servicesCollection, IConfiguration configuration)
        {
            servicesCollection.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
            });

            return servicesCollection;
        }
    }
}
