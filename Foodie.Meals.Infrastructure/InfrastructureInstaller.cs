using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Infrastructure.Repositories;
using Foodie.Shared.Cache;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foodie.Meals.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection AddMealsInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MealsDbContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("DbConnection"))
            );

            services.AddCache(configuration);

            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.Decorate<ICategoriesRepository, CachedCategoriesRepository>();
            services.AddScoped<ICitiesRepository, CitiesRepository>();
            services.AddScoped<ILocationsRepository, LocationsRepository>();
            services.AddScoped<IMealsRepository, MealsRepository>();
            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();

            return services;
        }
    }
}
