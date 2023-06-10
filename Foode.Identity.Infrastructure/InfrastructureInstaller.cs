using Foode.Identity.Infrastructure.Repositories;
using Foode.Identity.Infrastructure.Services;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Shared.Cache;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Foode.Identity.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Password.RequiredLength = 8;
                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
            });

            services.AddCache(configuration);

            services.AddTransient<IApplicationUsersRepository, ApplicationUsersRepository>();
            services.AddTransient<IAdminsRepository, AdminsRepository>();
            services.Decorate<IAdminsRepository, CachedAdminsRepository>();
            services.AddTransient<ICustomersRepository, CustomersRepository>();
            services.Decorate<ICustomersRepository, CachedCustomersRepository>();
            services.AddTransient<IOrderHandlersRepository, OrderHandlersRepository>();
            services.Decorate<IOrderHandlersRepository, CachedOrderHandlersRepository>();
            services.AddTransient<IApplicationUserRefreshTokensRepository, ApplicationUserRefreshTokensRepository>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IPasswordService, PasswordService>();

            return services;
        }
    }
}
