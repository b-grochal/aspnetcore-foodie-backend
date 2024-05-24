using Foodie.Common.Application.Requests.Queries.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMeals
{
    public class GetMealsQuery : PagedQuery, IRequest<Result<GetMealsQueryResponse>>
    {
        public int? RestaurantId { get; set; }
        public string Name { get; set; }
    }
}
