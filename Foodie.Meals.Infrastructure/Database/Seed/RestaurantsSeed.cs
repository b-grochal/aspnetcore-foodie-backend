﻿using Foodie.Meals.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Foodie.Meals.Infrastructure.Database.Seed
{
    public class RestaurantsSeed
    {
        public static List<Restaurant> Get()
        {
            return new List<Restaurant>()
            {
                new Restaurant()
                {
                    Id =  SeedConsts.KfcRestaurant,
                    Name = "KFC",
                    IsDeleted = false
                },
                new Restaurant()
                {
                    Id =  SeedConsts.PizzaHutRestaurant,
                    Name = "Pizza Hut",
                    IsDeleted = false
                },
                new Restaurant()
                {
                    Id =  SeedConsts.McDonaldsRestaurant,
                    Name = "McDonald's",
                    IsDeleted = false
                }
            };
        }
    }
}
