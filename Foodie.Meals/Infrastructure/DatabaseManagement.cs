using Foodie.Meals.Context;
using Foodie.Meals.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure
{
    public static class DatabaseManagement
    {
        public static void PreparePopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<MealsDbContext>());
            }
        }

        public static void SeedData(MealsDbContext context)
        {
            context.Database.Migrate();

            if (!context.Restaurants.Any())
            {
                context.Restaurants.AddRange(
                    new Restaurant { Name = "BurgerKing" }
                );
                context.SaveChanges();
            }
        }
    }
}
