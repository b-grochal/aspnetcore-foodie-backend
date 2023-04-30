using EasyCaching.Core.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Shared.Cache
{
    public static class CacheInstaller
    {
        public static IServiceCollection AddCache(this IServiceCollection servicesCollection, IConfiguration configuration)
        {
            var cacheConfiguration = configuration.GetSection(nameof(CacheConfiguration)).Get<CacheConfiguration>();

            servicesCollection.AddEasyCaching(options =>
            {
                options.UseRedis(config =>
                {
                    config.DBConfig.Endpoints.Add(new ServerEndPoint(cacheConfiguration.Host, cacheConfiguration.Port));
                }, "FoodieRedisCache");
            });

            return servicesCollection;
        }
    }
}
