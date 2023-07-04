using Microsoft.Extensions.Configuration;
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
