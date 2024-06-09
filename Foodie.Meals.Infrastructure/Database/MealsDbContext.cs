using Foodie.Common.Infrastructure.Database.Contexts;
using Foodie.Meals.Domain.Entities;
using Foodie.Meals.Infrastructure.Database.Seed;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Foodie.Meals.Infrastructure.Database
{
    public class MealsDbContext : BaseDbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }

        public MealsDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var category in CategoriesSeed.Get())
            {
                modelBuilder.Entity<Category>().HasData(category);
            }

            foreach (var country in CountriesSeed.Get())
            {
                modelBuilder.Entity<Country>().HasData(country);
            }

            foreach (var city in CitiesSeed.Get())
            {
                modelBuilder.Entity<City>().HasData(city);
            }

            foreach (var location in LocationsSeed.Get())
            {
                modelBuilder.Entity<Location>().HasData(location);
            }

            foreach (var meal in MealsSeed.Get())
            {
                modelBuilder.Entity<Meal>().HasData(meal);
            }

            foreach (var restaurant in RestaurantsSeed.Get())
            {
                modelBuilder.Entity<Restaurant>().HasData(restaurant);
            }

            modelBuilder.Entity(CategoryRestaurantsSeed.JoinTableName)
                .HasData(CategoryRestaurantsSeed.Get().Select(x => new
                {
                    RestaurantsId = x.RestaurantId,
                    CategoriesId = x.CategoryId
                }).ToArray());

            modelBuilder
                .Entity<Category>()
                .HasQueryFilter(e => !e.IsDeleted);

            modelBuilder
                .Entity<Country>()
                .HasQueryFilter(e => !e.IsDeleted);

            modelBuilder
                .Entity<City>()
                .HasQueryFilter(e => !e.IsDeleted);

            modelBuilder
                .Entity<Location>()
                .HasQueryFilter(e => !e.IsDeleted);

            modelBuilder
                .Entity<Meal>()
                .HasQueryFilter(e => !e.IsDeleted);

            modelBuilder
                .Entity<Restaurant>()
                .HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
