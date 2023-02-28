using Foodie.Meals.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.DummyData
{
    public class DummyCategories
    {
        public static List<Category> Get()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = DummySeed.PastaCategory,
                    Name = "Pasta",
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Category
                {
                    Id = DummySeed.BurgerCategory,
                    Name = "Burger",
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Category
                {
                    Id = DummySeed.PizzaCategory,
                    Name = "Pizza",
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
                new Category
                {
                    Id = DummySeed.SaladCategory,
                    Name = "Salad",
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                },
            };
        }
    }
}
