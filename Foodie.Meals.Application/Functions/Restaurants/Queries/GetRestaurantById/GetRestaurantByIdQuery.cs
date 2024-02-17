using MediatR;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery : IRequest<GetRestaurantByIdQueryResponse>
    {
        public int Id { get; }

        public GetRestaurantByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
