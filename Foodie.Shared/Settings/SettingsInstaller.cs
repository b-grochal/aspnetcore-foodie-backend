using Foodie.Shared.Authentication;
using Foodie.Shared.Cache;
using Foodie.Shared.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace Foodie.Shared.Settings
{
    public static class SettingsInstaller
    {
        public static IHostBuilder AddApplicationSettings(this IHostBuilder hostBuilder, params SettingsType[] settingsTypes)
        {
            return hostBuilder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddSettings(hostingContext.HostingEnvironment, settingsTypes)
                .AddJsonFile("appsettings.json", optional: true);
            });
        }

        public static IServiceCollection ConfigureApplicationSettings(this IServiceCollection serviceCollection, IConfiguration configuration, params SettingsType[] settingsTypes)
        {
            foreach (var settingsType in settingsTypes)
            {
                serviceCollection.ConfigureSettings(configuration, settingsType);
            }

            return serviceCollection;
        }

        private static IServiceCollection ConfigureSettings(this IServiceCollection serviceCollection, IConfiguration configuration, SettingsType settingsType)
        {
            switch(settingsType)
            {
                case SettingsType.JwtToken:
                    serviceCollection.Configure<JwtTokenSettings>(configuration.GetSection(nameof(JwtTokenSettings)));
                    break;
                case SettingsType.Redis:
                    serviceCollection.Configure<RedisSettings>(configuration.GetSection(nameof(RedisSettings)));
                    break;
                case SettingsType.Cache:
                    serviceCollection.Configure<CacheSettings>(configuration.GetSection(nameof(CacheSettings)));
                    break;
            }

            return serviceCollection;
        }

        private static IConfigurationBuilder AddSettings(this IConfigurationBuilder configurationBuilder, IHostEnvironment hostEnvironment, params SettingsType[] settingsTypes)
        {
            foreach (var settingsType in settingsTypes)
            {
                configurationBuilder.AddJsonFile(GetSettingsPath(hostEnvironment, settingsType));
            }

            return configurationBuilder;
        }

        private static string GetSettingsPath(IHostEnvironment hostEnvironment, SettingsType settingsType)
        {
            return settingsType switch
            {
                SettingsType.JwtToken => Path.Combine(hostEnvironment.ContentRootPath, "..", "Foodie.Shared", "Authentication", "jwtTokenSettings.json"),
                SettingsType.Redis => Path.Combine(hostEnvironment.ContentRootPath, "..", "Foodie.Shared", "Redis", "redisSettings.json"),
                SettingsType.Cache => Path.Combine(hostEnvironment.ContentRootPath, "..", "Foodie.Shared", "Cache", "cacheSettings.json"),
                _ => throw new ArgumentException($"Unsupported settings type: {settingsType}")
            };
        }
    }
}
