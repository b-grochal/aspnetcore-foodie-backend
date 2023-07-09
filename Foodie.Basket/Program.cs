using Foodie.Basket.API.IntegrationEventsHandlers;
using Foodie.Shared.Settings;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Foodie.Basket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<OrderStartedIntegrationEventHandler>();
                        x.SetKebabCaseEndpointNameFormatter();
                        x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
                    });
                })
                .AddApplicationSettings(SettingsType.JwtToken, SettingsType.Cache);
    }
}
