//using Foodie.Common.Api.Settings;
//using Foodie.Orders.Application.Features.IntegrationEventsHandlers;
//using MassTransit;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Hosting;

//namespace Foodie.Orders.API
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                })
//                .AddApplicationSettings(SettingsType.JwtToken, SettingsType.Smtp)
//                .ConfigureServices(services =>
//                {
//                    services.AddMassTransit(x =>
//                    {
//                        x.AddConsumer<CustomerCheckoutIntegrationEventHandler>();
//                        x.SetKebabCaseEndpointNameFormatter();
//                        x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
//                    });
//                });
//    }
//}

using Foodie.Common.Api.Exceptions;
using Foodie.Common.Api.Settings;
using Foodie.Common.Infrastructure.Authentication;
using Foodie.Common.Infrastructure.Hangfire;
using Foodie.Emails;
using Foodie.Orders.Application;
using Foodie.Orders.Application.Features.IntegrationEventsHandlers;
using Foodie.Orders.Infrastructure;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

Log.Logger = new LoggerConfiguration()
    .ReadFrom
    .Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.AddApplicationSettings(SettingsType.JwtToken, SettingsType.Smtp);

builder.Host.UseSerilog();

builder.Services.AddOrdersApplication();
builder.Services.AddOrdersInfrastructure(builder.Configuration);
builder.Services.ConfigureApplicationSettings(builder.Configuration, SettingsType.JwtToken, SettingsType.Smtp);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddEmails();
builder.Services.AddHangfire(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Foodie.Orders.API", Version = "v1" });
});

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CustomerCheckoutIntegrationEventHandler>();
    x.SetKebabCaseEndpointNameFormatter();
    x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

//app.UseSerilog();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foodie.Orders.API v1"));
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHangifreDashboardTool();

app.Run();
