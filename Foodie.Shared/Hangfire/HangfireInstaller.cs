using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foodie.Shared.Hangfire
{
    public static class HangfireInstaller
    {
        public static IServiceCollection AddHangfire(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddHangfire(x =>
            {
                x.UseSqlServerStorage(configuration.GetConnectionString("DbConnection"));
            });

            serviceCollection.AddHangfireServer();

            return serviceCollection;
        }

        public static IApplicationBuilder UseHangifreDashboardTool(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseHangfireDashboard();
        }
    }
}
