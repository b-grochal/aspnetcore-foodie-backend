using Foodie.Meals.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.DummyData
{
    public class DummyMeals
    {
        public static List<Meal> Get()
        {
            return new List<Meal>()
            {
                new Meal()
                {
                    Name = "Longer",
                    Description = "Longer",
                    Price = 12,
                    RestaurantId = DummySeed.KfcRestaurant,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Meal()
                {
                    Name = "Zinger",
                    Description = "Zinger",
                    Price = 10,
                    RestaurantId = DummySeed.KfcRestaurant,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Meal()
                {
                    Name = "Pizza Texas",
                    Description = "Pizza Texas",
                    Price = 12,
                    RestaurantId = DummySeed.PizzaHutRestaurant,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Meal()
                {
                    Name = "Pizza Carbonara",
                    Description = "Pizza Carbonara",
                    Price = 12,
                    RestaurantId = DummySeed.PizzaHutRestaurant,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Meal()
                {
                    Name = "Big Mac",
                    Description = "Big Mac",
                    Price = 15,
                    RestaurantId = DummySeed.McDonaldsRestaurant,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Meal()
                {
                    Name = "McRoyal",
                    Description = "McRoyal",
                    Price = 10,
                    RestaurantId = DummySeed.McDonaldsRestaurant,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
            };
        }
    }
}
