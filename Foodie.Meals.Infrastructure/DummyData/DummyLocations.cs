using Foodie.Meals.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.DummyData
{
    public class DummyLocations
    {
        public static List<Location> Get()
        {
            return new List<Location>
            {
                new Location
                {
                    Address = "Kfc Las Vegas",
                    PhoneNumber = "123-123-213",
                    Email = "kfc.lasvegas@email.com",
                    CityId = DummySeed.LasVegasCity,
                    RestaurantId = DummySeed.KfcRestaurant,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Location
                {
                    Address = "Kfc Los Angeles",
                    PhoneNumber = "123-123-213",
                    Email = "kfc.losangeles@email.com",
                    CityId = DummySeed.LosAngelesCity,
                    RestaurantId = DummySeed.KfcRestaurant,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Location
                {
                    Address = "Kfc New York",
                    PhoneNumber = "123-123-213",
                    Email = "kfc.newyork@email.com",
                    CityId = DummySeed.NewYorkCity,
                    RestaurantId = DummySeed.KfcRestaurant,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Location
                {
                    Address = "Pizza Hut Las Vegas",
                    PhoneNumber = "123-123-213",
                    Email = "pizzahut.lasvegas@email.com",
                    CityId = DummySeed.LasVegasCity,
                    RestaurantId = DummySeed.PizzaHutRestaurant,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Location
                {
                    Address = "Pizza Hut Los Angeles",
                    PhoneNumber = "123-123-213",
                    Email = "pizzahut.losangeles@email.com",
                    CityId = DummySeed.LosAngelesCity,
                    RestaurantId = DummySeed.PizzaHutRestaurant,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Location
                {
                    Address = "McDonald's Las Vegas",
                    PhoneNumber = "123-123-213",
                    Email = "mcdonalds.lasvegas@email.com",
                    CityId = DummySeed.LasVegasCity,
                    RestaurantId = DummySeed.McDonaldsRestaurant,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                }
            };
        }
    }
}
