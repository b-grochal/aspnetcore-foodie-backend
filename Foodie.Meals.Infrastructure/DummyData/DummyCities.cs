using Foodie.Meals.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.DummyData
{
    public class DummyCities
    {
        public static List<City> Get()
        {
            return new List<City>
            {
                new City
                {
                    Id = DummySeed.LasVegasCity,
                    Name = "Las Vegas",
                    Country = "USA",
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new City
                {
                    Id = DummySeed.LosAngelesCity,
                    Name = "Los Angeles",
                    Country = "USA",
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new City
                {
                    Id = DummySeed.NewYorkCity,
                    Name = "New York",
                    Country = "USA",
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                }
            };
        }
    }
}
