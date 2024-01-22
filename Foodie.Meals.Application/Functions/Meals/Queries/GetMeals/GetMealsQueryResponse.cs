using Foodie.Common.Application.Responses;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMeals
{
    public class GetMealsQueryResponse : PagedResponse<MealDto>
    {
        public int? RestaurantId { get; set; }
        public string Name { get; set; }
    }

    public class MealDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int RestaurantId { get; set; }
    }
}
