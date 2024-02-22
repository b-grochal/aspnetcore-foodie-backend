using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Infrastructure.Database;
using Foodie.Common.Infrastructure.Database.Interfaces;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Buyers;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Contractors;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Infrastructure.Contexts;
using Foodie.Orders.Infrastructure.Queries;
using Foodie.Orders.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foodie.Orders.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection AddOrdersInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrdersDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

            services.AddScoped<IDbContext, OrdersDbContext>();

            services.AddSingleton<DapperContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IBuyersRepository, BuyersRepository>();
            services.AddScoped<IContractorsRepository, ContractorsRepository>();
            services.AddScoped<IOrdersQueries, OrdersQueries>();
            services.AddScoped<IContractorsQueries, ContractorsQueries>();
            services.AddScoped<IBuyersQueries, BuyersQueries>();

            return services;
        }
    }
}
