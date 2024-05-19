using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery : IRequest<Result<GetRestaurantByIdQueryResponse>>
    {
        public int Id { get; }

        public GetRestaurantByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
