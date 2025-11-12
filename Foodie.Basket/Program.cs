//using Foodie.Basket.API.IntegrationEventsHandlers;
//using Foodie.Common.Api.Settings;
//using MassTransit;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Hosting;

//namespace Foodie.Basket
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
//                .ConfigureServices((hostContext, services) =>
//                {
//                    services.AddMassTransit(x =>
//                    {
//                        x.AddConsumer<OrderStartedIntegrationEventHandler>();
//                        x.SetKebabCaseEndpointNameFormatter();
//                        x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
//                    });
//                })
//                .AddApplicationSettings(SettingsType.JwtToken, SettingsType.Cache);
//    }
//}

using FluentValidation;
using Foodie.Basket.API.IntegrationEventsHandlers;
using Foodie.Basket.Repositories.Implementations;
using Foodie.Basket.Repositories.Interfaces;
using Foodie.Common.Api.Exceptions;
using Foodie.Common.Api.Settings;
using Foodie.Common.Application.Behaviours;
using Foodie.Common.Application.Contracts.Infrastructure.Authentication;
using Foodie.Common.Infrastructure.Authentication;
using Foodie.Common.Infrastructure.Cache;
using Foodie.Shared.Behaviours;
using IdentityGrpc;
using MassTransit;
using MealsGrpc;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

Log.Logger = new LoggerConfiguration()
    .ReadFrom
    .Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.AddApplicationSettings(SettingsType.JwtToken, SettingsType.Cache);

builder.Host.UseSerilog();

builder.Services.ConfigureApplicationSettings(builder.Configuration, SettingsType.JwtToken);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddCache(builder.Configuration);
builder.Services.AddScoped<ICustomerBasketsRepository, CustomerBasketsRepository>();
builder.Services.AddTransient<IApplicationUserContext, ApplicationUserContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ApplicationUserIdBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
builder.Services.AddHttpContextAccessor();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<OrderStartedIntegrationEventHandler>();
    x.SetKebabCaseEndpointNameFormatter();
    x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
});

builder.Services.AddGrpcClient<IdentityService.IdentityServiceClient>(opt =>
{
    opt.Address = new Uri("https://localhost:5004");
});

builder.Services.AddGrpcClient<MealsService.MealsServiceClient>(opt =>
{
    opt.Address = new Uri("https://localhost:5006");
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Foodie.Basket", Version = "v1" });
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

//app.UseSerilog();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foodie.Basket v1"));
}

//app.UseMiddleware<ExceptionMiddleware>();
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => 
{
    endpoints.MapControllers();
});

app.Run();

