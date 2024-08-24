using Foodie.Common.Application.Contracts.Infrastructure.Authentication;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Infrastructure.Authentication;
using Foodie.Common.Infrastructure.Database;
using Foodie.Common.Infrastructure.Database.Connections;
using Foodie.Common.Infrastructure.Database.Connections.Interfaces;
using Foodie.Common.Infrastructure.Database.Contexts.Interfaces;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Buyers;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Contractors;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using Foodie.Orders.Infrastructure.Database;
using Foodie.Orders.Infrastructure.Database.Repositories;
using Foodie.Orders.Infrastructure.Database.SqlQueries;
using Foodie.Orders.Infrastructure.Database.UnitOfWork;
using Foodie.Orders.Infrastructure.Queries;
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

            services.AddSingleton<IDbConnecionFactory, DbConnectionFactory>();

            services.AddScoped<IUnitOfWork, OrdersUnitOfWork>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IBuyersRepository, BuyersRepository>();
            services.AddScoped<IContractorsRepository, ContractorsRepository>();
            services.AddScoped<IOrdersReadServcie, OrdersReadService>();
            services.AddScoped<IContractorsQueries, ContractorsQueries>();
            services.AddScoped<IBuyersQueries, BuyersQueries>();
            services.AddTransient<IApplicationUserContext, ApplicationUserContext>();
            services.AddSingleton<IDbConnecionFactory, DbConnectionFactory>();
            services.AddHttpContextAccessor();

            services.AddScoped<IGetMyOrderByIdSqlQuery, GetMyOrderByIdSqlQuery>();
            services.AddScoped<IGetOrderByIdSqlQuery, GetOrderByIdSqlQuery>();
            services.AddScoped<IGetOrdersSqlQuery, GetOrdersSqlQuery>();
            services.AddScoped<IGetMyOrdersSqlQuery, GetMyOrdersSqlQuery>();


            return services;
        }
    }
}
