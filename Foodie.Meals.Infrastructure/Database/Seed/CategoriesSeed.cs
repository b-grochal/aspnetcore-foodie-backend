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
                    IsDeleted = false
                },
                new Category
                {
                    Id = SeedConsts.BurgerCategory,
                    Name = "Burger",
                    IsDeleted = false
                },
                new Category
                {
                    Id = SeedConsts.PizzaCategory,
                    Name = "Pizza",
                    IsDeleted = false
                },
                new Category
                {
                    Id = SeedConsts.SaladCategory,
                    Name = "Salad",
                    IsDeleted = false
                },
            };
        }
    }
}
