using Foodie.Meals.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.DummyData
{
    public class DummyRestaurants
    {
        public static List<Restaurant> Get()
        {
            return new List<Restaurant>()
            {
                new Restaurant()
                {
                    RestaurantId =  DummySeed.KfcRestaurant,
                    Name = "KFC",
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Restaurant()
                {
                    RestaurantId =  DummySeed.PizzaHutRestaurant,
                    Name = "Pizza Hut",
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Restaurant()
                {
                    RestaurantId =  DummySeed.McDonaldsRestaurant,
                    Name = "McDonald's",
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                }
            };
        }
    }
}
