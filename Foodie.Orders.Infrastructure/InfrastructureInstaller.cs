using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Buyers;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Contractors;
using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Infrastructure.Contexts;
using Foodie.Orders.Infrastructure.Queries;
using Foodie.Orders.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection AddOrdersInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrdersDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            services.AddSingleton<DapperContext>();

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
