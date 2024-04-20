using Foodie.Meals.Domain.Entities;
using System.Collections.Generic;

namespace Foodie.Meals.Infrastructure.Database.Seed
{
    public class CountriesSeed
    {
        public static List<Country> Get()
        {
            return new List<Country>
            {
                new Country
                {
                    Id = SeedConsts.UsaCountry,
                    Name = "USA"
                },
                new Country
                {
                    Id = SeedConsts.GermanyCountry,
                    Name = "Germany"
                }
            };
        }
    }
}
