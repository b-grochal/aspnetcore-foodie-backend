using Foodie.Meals.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Foodie.Meals.Infrastructure.Database.Seed
{
    public class LocationsSeed
    {
        public static List<Location> Get()
        {
            return new List<Location>
            {
                new Location
                {
                    Id = SeedConsts.KfcLasVegasLocation,
                    Address = "Kfc Las Vegas",
                    PhoneNumber = "123-123-213",
                    Email = "kfc.lasvegas@email.com",
                    CityId = SeedConsts.LasVegasCity,
                    RestaurantId = SeedConsts.KfcRestaurant,
                    IsDeleted = false
                },
                new Location
                {
                    Id = SeedConsts.KfcLosAngelesLocation,
                    Address = "Kfc Los Angeles",
                    PhoneNumber = "123-123-213",
                    Email = "kfc.losangeles@email.com",
                    CityId = SeedConsts.LosAngelesCity,
                    RestaurantId = SeedConsts.KfcRestaurant,
                    IsDeleted = false
                },
                new Location
                {
                    Id = SeedConsts.KfcNewYorkLocation,
                    Address = "Kfc New York",
                    PhoneNumber = "123-123-213",
                    Email = "kfc.newyork@email.com",
                    CityId = SeedConsts.NewYorkCity,
                    RestaurantId = SeedConsts.KfcRestaurant,
                    IsDeleted = false
                },
                new Location
                {
                    Id = SeedConsts.PizzaHutLasVegasLocation,
                    Address = "Pizza Hut Las Vegas",
                    PhoneNumber = "123-123-213",
                    Email = "pizzahut.lasvegas@email.com",
                    CityId = SeedConsts.LasVegasCity,
                    RestaurantId = SeedConsts.PizzaHutRestaurant,
                    IsDeleted = false
                },
                new Location
                {
                    Id = SeedConsts.PizzaHutLosAngelesLocation,
                    Address = "Pizza Hut Los Angeles",
                    PhoneNumber = "123-123-213",
                    Email = "pizzahut.losangeles@email.com",
                    CityId = SeedConsts.LosAngelesCity,
                    RestaurantId = SeedConsts.PizzaHutRestaurant,
                    IsDeleted = false
                },
                new Location
                {
                    Id = SeedConsts.McDonaldsLasVegasLocation,
                    Address = "McDonald's Las Vegas",
                    PhoneNumber = "123-123-213",
                    Email = "mcdonalds.lasvegas@email.com",
                    CityId = SeedConsts.LasVegasCity,
                    RestaurantId = SeedConsts.McDonaldsRestaurant,
                    IsDeleted = false
                }
            };
        }
    }
}
