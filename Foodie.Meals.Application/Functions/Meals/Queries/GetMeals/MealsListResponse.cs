using Foodie.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMeals
{
    public class MealsListResponse : PagedResponse
    {
        public IEnumerable<MealResponse> Meals { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
    }
}
