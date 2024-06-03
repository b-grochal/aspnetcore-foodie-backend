using Foode.Identity.Infrastructure.ApplicationUserUtilities;
using Foode.Identity.Infrastructure.Database.Repositories;
using Foode.Identity.Infrastructure.Database.UnitOfWork;
using Foodie.Common.Application.Contracts.Infrastructure.Authentication;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Infrastructure.Authentication;
using Foodie.Common.Infrastructure.Cache;
using Foodie.Common.Infrastructure.Database.Connections.Interfaces;
using Foodie.Common.Infrastructure.Database.Connections;
using Foodie.Common.Infrastructure.Database.Interceptors;
using Foodie.Identity.Application.Contracts.Infrastructure.ApplicationUserUtilities;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
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
            services.AddSingleton<SoftDeleteForDomainEntitiesInterceptor>();

            services.AddDbContext<IdentityDbContext>((sp, options) => options
                .UseSqlServer(configuration.GetConnectionString("DbConnection"))
                .AddInterceptors(
                    sp.GetRequiredService<SoftDeleteForDomainEntitiesInterceptor>()));

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Password.RequiredLength = 8;
                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
            });

            services.AddCache(configuration);

            services.AddScoped<IUnitOfWork, IdentityUnitOfWork>();
            services.AddTransient<IApplicationUsersRepository, ApplicationUsersRepository>();
            services.AddTransient<IAdminsRepository, AdminsRepository>();
            services.Decorate<IAdminsRepository, CachedAdminsRepository>();
            services.AddTransient<ICustomersRepository, CustomersRepository>();
            services.Decorate<ICustomersRepository, CachedCustomersRepository>();
            services.AddTransient<IOrderHandlersRepository, OrderHandlersRepository>();
            services.Decorate<IOrderHandlersRepository, CachedOrderHandlersRepository>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IRefreshTokenService, RefreshTokenService>();
            services.AddTransient<IAccountTokensService, AccountTokensService>();
            services.AddTransient<IApplicationUserContext, ApplicationUserContext>();
            services.AddSingleton<IDbConnecionFactory, DbConnectionFactory>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
