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
                    CategoryId = DummySeed.PastaCategory,
                    Name = "Pasta"
                },
                new Category
                {
                    CategoryId = DummySeed.BurgerCategory,
                    Name = "Burger"
                },
                new Category
                {
                    CategoryId = DummySeed.PizzaCategory,
                    Name = "Pizza"
                },
                new Category
                {
                    CategoryId = DummySeed.SaladCategory,
                    Name = "Salad"
                },
            };
        }
    }
}
