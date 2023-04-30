using Foodie.Shared.Authentication;
using Foodie.Shared.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Foodie.Shared.Settings
{
    public static class SettingsInstaller
    {
        public static IHostBuilder AddApplicationSettings(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile(GetSharedSettingsPath(hostingContext.HostingEnvironment), optional: true)
                .AddJsonFile("appsettings.json", optional: true);
            });
        }

        public static IServiceCollection ConfigureApplicationSettings(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<JwtTokenConfiguration>(configuration.GetSection(nameof(JwtTokenConfiguration)));
            serviceCollection.Configure<RedisConfiguration>(configuration.GetSection(nameof(RedisConfiguration)));
            return serviceCollection;
        }

        public static string GetSharedSettingsPath(IHostEnvironment hostEnvironment)
        {
            return Path.Combine(hostEnvironment.ContentRootPath, "..", "Foodie.Shared", "Settings", "settings.json");
        }
    }
}
