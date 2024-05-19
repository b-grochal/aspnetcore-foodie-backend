using Foodie.Common.Domain.Entities.Interfaces;
using Foodie.Common.Infrastructure.Database.Interfaces;
using Foodie.Meals.Domain.Entities;
using Foodie.Meals.Infrastructure.Database.Seed;
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
        }

        public Task<int> CommitChangesAsync(string user, CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries<IIsAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property(nameof(IIsAuditable.CreatedDate)).CurrentValue = DateTimeOffset.Now;
                        entry.Property(nameof(IIsAuditable.CreatedBy)).CurrentValue = user;
                        break;
                    case EntityState.Modified:
                        entry.Property(nameof(IIsAuditable.LastModifiedDate)).CurrentValue = DateTimeOffset.Now;
                        entry.Property(nameof(IIsAuditable.LastModifiedBy)).CurrentValue = user;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
