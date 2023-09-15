using Foodie.Shared.Responses;
using System.Collections.Generic;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMeals
{
    public class GetMealsQueryResponse : PagedResponse
    {
        public IEnumerable<MealDto> Meals { get; set; }
        public int? RestaurantId { get; set; }
        public string Name { get; set; }
    }

    public class MealDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
