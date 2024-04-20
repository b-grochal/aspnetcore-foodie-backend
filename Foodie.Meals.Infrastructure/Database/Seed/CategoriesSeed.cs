using Foodie.Meals.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Foodie.Meals.Infrastructure.Database.Seed
{
    public class CategoriesSeed
    {
        public static List<Category> Get()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = SeedConsts.PastaCategory,
                    Name = "Pasta",
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Category
                {
                    Id = SeedConsts.BurgerCategory,
                    Name = "Burger",
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Category
                {
                    Id = SeedConsts.PizzaCategory,
                    Name = "Pizza",
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Category
                {
                    Id = SeedConsts.SaladCategory,
                    Name = "Salad",
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
            };
        }
    }
}
