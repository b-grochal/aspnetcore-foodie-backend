using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantMeals
{
    public class GetRestaurantMealsQuery : IRequest<Result<GetRestaurantsMealsQueryResponse>>
    {
        public int Id { get; }

        public GetRestaurantMealsQuery(int id)
        {
            Id = id;
        }
    }
}
