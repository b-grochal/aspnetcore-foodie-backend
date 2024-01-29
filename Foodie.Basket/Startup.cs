using Foodie.Basket.Repositories.Implementations;
using Foodie.Basket.Repositories.Interfaces;
using Foodie.Common.Api.Middlewares;
using Foodie.Common.Infrastructure.Authentication;
using Foodie.Common.Infrastructure.Cache;
using Foodie.Shared.Settings;
using IdentityGrpc;
using MealsGrpc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using MediatR;

namespace Foodie.Basket
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Foodie.Basket", Version = "v1" });
            });

            services.ConfigureApplicationSettings(Configuration, SettingsType.JwtToken);
            services.AddJwtAuthentication(Configuration);
            services.AddCache(Configuration);
            services.AddScoped<ICustomerBasketsRepository, CustomerBasketsRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediator(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());



            services.AddGrpcClient<IdentityService.IdentityServiceClient>(opt =>
            {
                opt.Address = new Uri("https://localhost:5004");
            });

            services.AddGrpcClient<MealsService.MealsServiceClient>(opt =>
            {
                opt.Address = new Uri("https://localhost:5006");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foodie.Basket v1"));
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
