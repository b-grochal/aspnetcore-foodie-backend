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
            services.Decorate<ICitiesRepository, CachedCitiesRepository>();
            services.AddScoped<ILocationsRepository, LocationsRepository>();
            services.Decorate<ILocationsRepository, CachedLocationsRepository>();
            services.AddScoped<IMealsRepository, MealsRepository>();
            services.Decorate<IMealsRepository, CachedMealsRepository>();
            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
            services.Decorate<IRestaurantsRepository, CachedRestaurantsRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.Decorate<ICountriesRepository, CachedCountriesRepository>();

            return services;
        }
    }
}
