using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMeals
{
    public class MealResponse
    {
        public int MealId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
