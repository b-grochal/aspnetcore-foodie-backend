using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Foodie.Shared.Behaviours;
using Foodie.Shared.Authorization;

namespace Foodie.Orders.Application
{
    public static class ApplicationInstallation
    {
        public static IServiceCollection AddOrdersApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestAuthorizationBehaviour<,>));
            services.AddAuthorizersFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
