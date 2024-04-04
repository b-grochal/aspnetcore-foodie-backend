//using Foodie.Common.Api.Settings;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//using Serilog;

//namespace Foodie.Identity
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            IConfigurationRoot configuration = new ConfigurationBuilder()
//                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                .Build();

//            Log.Logger = new LoggerConfiguration()
//                .ReadFrom
//                .Configuration(configuration)
//                .CreateLogger();

//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                })
//                .AddApplicationSettings(SettingsType.JwtToken, SettingsType.Cache, SettingsType.Smtp)
//                .UseSerilog();
//    }
//}

using Foode.Identity.Infrastructure;
using Foodie.Common.Api.Middlewares;
using Foodie.Common.Api.Settings;
using Foodie.Common.Application.Behaviours;
using Foodie.Common.Infrastructure.Authentication;
using Foodie.Common.Infrastructure.Hangfire;
using Foodie.Emails;
using Foodie.Identity.API.Grpc;
using Foodie.Identity.Application;
using Foodie.Shared.Behaviours;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

Log.Logger = new LoggerConfiguration()
    .ReadFrom
    .Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.AddApplicationSettings();

builder.Host.UseSerilog();

builder.Services.AddIdentityApplication();
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.ConfigureApplicationSettings(builder.Configuration, SettingsType.JwtToken, SettingsType.Smtp);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddEmails();
builder.Services.AddHangfire(builder.Configuration);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuditableBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ApplicationUserLocationBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ApplicationUserIdBehaviour<,>));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Foodie.Identity", Version = "v1" });
});



builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddGrpc();

var app = builder.Build();

//app.UseSerilog();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foodie.Identity v1"));
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<IdentityGrpcService>();
    endpoints.MapControllers();
});

app.Run();
