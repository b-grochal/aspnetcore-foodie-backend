using Foode.Identity.Infrastructure.Repositories;
using Foode.Identity.Infrastructure.Services;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure
{
    public static class InfrastructureInstallation
    {
        public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            services.AddIdentityCore<ApplicationUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<IdentityDbContext>();

            services.AddTransient<IAdminsRepository, AdminsRepository>();
            services.AddTransient<ICustomersRepository, CustomersRepository>();
            services.AddTransient<IOrderHandlersRepository, OrderHandlersRepository>();
            services.AddTransient<IApplicationUserRolesRepository, ApplicationUserRolesRepository>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IJwtService, JwtService>();

            return services;
        }
    }
}
