using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand : IRequest<Result<DeleteRestaurantCommandResponse>>, IAuditableCommand
    {
        public int Id { get; set; }

        public string User { get; set; }

        public DeleteRestaurantCommand(int id)
        {
            this.Id = id;
        }
    }
}
