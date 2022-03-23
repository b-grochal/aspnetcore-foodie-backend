using Foodie.Meals.Domain.Entities;
using Foodie.Meals.Infrastructure.DummyData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure
{
    public class MealsDbContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MealsDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var category in DummyCategories.Get())
            {
                modelBuilder.Entity<Category>().HasData(category);
            }

            foreach (var city in DummyCities.Get())
            {
                modelBuilder.Entity<City>().HasData(city);
            }

            foreach (var location in DummyLocations.Get())
            {
                modelBuilder.Entity<Location>().HasData(location);
            }

            foreach (var meal in DummyMeals.Get())
            {
                modelBuilder.Entity<Meal>().HasData(meal);
            }

            foreach (var restaurant in DummyRestaurants.Get())
            {
                foreach(var category in DummyCategories.Get())
                {
                    restaurant.Categories.Add(category);
                }

                modelBuilder.Entity<Restaurant>().HasData(restaurant);
            }
        }
    }
}
