using Foodie.Common.Api.Settings;
using Foodie.Orders.Application.Features.IntegrationEventsHandlers;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Foodie.Orders.API
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
                .AddApplicationSettings(SettingsType.JwtToken, SettingsType.Smtp)
                .ConfigureServices(services =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<CustomerCheckoutIntegrationEventHandler>();
                        x.SetKebabCaseEndpointNameFormatter();
                        x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
                    });
                });
    }
}
