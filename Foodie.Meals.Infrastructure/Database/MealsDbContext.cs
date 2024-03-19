using Foodie.Common.Domain.Entities.Interfaces;
using Foodie.Common.Infrastructure.Database.Interfaces;
using Foodie.Meals.Domain.Entities;
using Foodie.Meals.Infrastructure.DummyData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Database
{
    public class MealsDbContext : DbContext, IDbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }

        public MealsDbContext(DbContextOptions options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IIsAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property(nameof(IIsAuditable.CreatedDate)).CurrentValue = DateTimeOffset.Now;
                        break;
                    case EntityState.Modified:
                        entry.Property(nameof(IIsAuditable.CreatedDate)).CurrentValue = DateTimeOffset.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var category in DummyCategories.Get())
            {
                modelBuilder.Entity<Category>().HasData(category);
            }

            foreach (var country in DummyCountries.Get())
            {
                modelBuilder.Entity<Country>().HasData(country);
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
                modelBuilder.Entity<Restaurant>().HasData(restaurant);
            }

            modelBuilder.Entity(DummyCategoryRestaurants.JoinTableName)
                .HasData(DummyCategoryRestaurants.Get().Select(x => new
                {
                    RestaurantsId = x.RestaurantId,
                    CategoriesId = x.CategoryId
                }).ToArray());
        }
    }
}
