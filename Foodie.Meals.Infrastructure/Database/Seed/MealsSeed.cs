using Foodie.Meals.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Foodie.Meals.Infrastructure.Database.Seed
{
    public class MealsSeed
    {
        public static List<Meal> Get()
        {
            return new List<Meal>()
            {
                new Meal()
                {
                    Id = SeedConsts.LongerMeal,
                    Name = "Longer",
                    Description = "Longer",
                    Price = 12,
                    RestaurantId = SeedConsts.KfcRestaurant,
                    IsDeleted = false
                },
                new Meal()
                {
                    Id = SeedConsts.ZingerMeal,
                    Name = "Zinger",
                    Description = "Zinger",
                    Price = 10,
                    RestaurantId = SeedConsts.KfcRestaurant,
                    IsDeleted = false
                },
                new Meal()
                {
                    Id = SeedConsts.PizzaTexasMeal,
                    Name = "Pizza Texas",
                    Description = "Pizza Texas",
                    Price = 12,
                    RestaurantId = SeedConsts.PizzaHutRestaurant,
                    IsDeleted = false
                },
                new Meal()
                {
                    Id = SeedConsts.PizzaCarbonaraMeal,
                    Name = "Pizza Carbonara",
                    Description = "Pizza Carbonara",
                    Price = 12,
                    RestaurantId = SeedConsts.PizzaHutRestaurant,
                    IsDeleted = false
                },
                new Meal()
                {
                    Id = SeedConsts.BigMacMeal,
                    Name = "Big Mac",
                    Description = "Big Mac",
                    Price = 15,
                    RestaurantId = SeedConsts.McDonaldsRestaurant,
                    IsDeleted = false
                },
                new Meal()
                {
                    Id = SeedConsts.McRoyalMeal,
                    Name = "McRoyal",
                    Description = "McRoyal",
                    Price = 10,
                    RestaurantId = SeedConsts.McDonaldsRestaurant,
                    IsDeleted = false
                },
            };
        }
    }
}
