using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Shared.Settings
{
    public static class Extensions
    {
        public static IHostBuilder AddApplicationSettings(this IHostBuilder hostBuilder) 
        {
            return hostBuilder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile(GetSharedSettingsPath(hostingContext.HostingEnvironment), optional: true)
                .AddJsonFile("appsettings.json", optional: true);
            });
        }

        public static string GetSharedSettingsPath(IHostEnvironment hostEnvironment)
        {
            return Path.Combine(hostEnvironment.ContentRootPath, "..", "Foodie.Shared", "Settings", "settings.json");
        }
    }
}
