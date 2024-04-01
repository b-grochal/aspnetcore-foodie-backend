using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand : IRequest<Result<DeleteRestaurantCommandResponse>>
    {
        public int Id { get; set; }

        public DeleteRestaurantCommand(int id)
        {
            this.Id = id;
        }
    }
}
