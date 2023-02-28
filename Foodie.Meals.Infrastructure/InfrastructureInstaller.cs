using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection AddMealsInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MealsDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICitiesRepository, CitiesRepository>();
            services.AddScoped<ILocationsRepository, LocationsRepository>();
            services.AddScoped<IMealsRepository, MealsRepository>();
            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();

            return services;
        }
    }
}
