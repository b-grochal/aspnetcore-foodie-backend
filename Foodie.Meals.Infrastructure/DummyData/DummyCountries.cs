using Foodie.Meals.Domain.Entities;
using System.Collections.Generic;

namespace Foodie.Meals.Infrastructure.DummyData
{
    public class DummyCountries
    {
        public static List<Country> Get()
        {
            return new List<Country>
            {
                new Country
                {
                    Id = DummySeed.UsaCountry,
                    Name = "USA"
                },
                new Country
                {
                    Id = DummySeed.GermanyCountry,
                    Name = "Germany"
                }
            };
        }
    }
}
