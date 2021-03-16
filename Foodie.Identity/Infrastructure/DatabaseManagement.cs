using Foodie.Identity.Context;
using Foodie.Identity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Infrastructure
{
    public static class DatabaseManagement
    {
        public static void PreparePopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<IdentityContext>(), serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>(), serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>());
            }
        }

        public static void SeedData(IdentityContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.Migrate();

            if (!roleManager.Roles.Any())
            {
                roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.Admin)).Wait();
                roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.User)).Wait();
                roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.OrderHandler)).Wait();
            }


            if (!context.Users.Any())
            {
                var applicationUser = new ApplicationUser
                {
                    FirstName = "Michael",
                    LastName = "Scott",
                    Email = "michael@scott.com",
                    UserName = "michael@scott.com",
                    PhoneNumber = "123-123-123",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                userManager.CreateAsync(applicationUser, "P@ssw0rd").Wait();
                userManager.AddToRoleAsync(applicationUser, ApplicationUserRoles.Admin).Wait();
            }
        }
    }
}

