using EasyCaching.Core.Configurations;
using EasyCaching.Serialization.SystemTextJson.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Foodie.Common.Infrastructure.Cache
{
    public static class CacheInstaller
    {
        public static IServiceCollection AddCache(this IServiceCollection servicesCollection, IConfiguration configuration)
        {
            var cacheConfiguration = configuration.GetSection(nameof(CacheSettings)).Get<CacheSettings>();

            servicesCollection.AddEasyCaching(options =>
            {
                options.UseRedis(config =>
                {
                    config.DBConfig.Endpoints.Add(new ServerEndPoint(cacheConfiguration.Host, cacheConfiguration.Port));
                    config.SerializerName = "json";
                }, "FoodieRedisCache")
                .WithSystemTextJson(jsonSerializerSettingsConfigure: serializerOptions =>
                {
                    serializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                }, name: "json");
            });

            servicesCollection.AddScoped<ICacheKeyGenerator, CacheKeyGenerator>();
            servicesCollection.AddScoped<ICacheService, CacheService>();

            return servicesCollection;
        }
    }
}
