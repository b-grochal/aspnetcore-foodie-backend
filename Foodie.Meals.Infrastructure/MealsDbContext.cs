using Foodie.Meals.Domain.Entities;
using Foodie.Meals.Infrastructure.DummyData;
using Foodie.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
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
        }
    }
}
