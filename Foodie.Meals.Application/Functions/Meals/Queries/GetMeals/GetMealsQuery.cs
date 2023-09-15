using Foodie.Shared.Queries;
using MediatR;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMeals
{
    public class GetMealsQuery : PagedQuery, IRequest<GetMealsQueryResponse>
    {
        public int? RestaurantId { get; set; }
        public string Name { get; set; }
    }
}
