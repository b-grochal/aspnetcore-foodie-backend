using Foodie.Meals.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Foodie.Meals.Infrastructure.Database.Seed
{
    public class CitiesSeed
    {
        public static List<City> Get()
        {
            return new List<City>
            {
                new City
                {
                    Id = SeedConsts.LasVegasCity,
                    Name = "Las Vegas",
                    CountryId = SeedConsts.UsaCountry
                },
                new City
                {
                    Id = SeedConsts.LosAngelesCity,
                    Name = "Los Angeles",
                    CountryId = SeedConsts.UsaCountry
                },
                new City
                {
                    Id = SeedConsts.NewYorkCity,
                    Name = "New York",
                    CountryId = SeedConsts.UsaCountry
                }
            };
        }
    }
}
