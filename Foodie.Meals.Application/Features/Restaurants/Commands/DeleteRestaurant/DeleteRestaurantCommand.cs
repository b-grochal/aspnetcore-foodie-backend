using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand : IRequest<Result<DeleteRestaurantCommandResponse>>, IAuditableCommand
    {
        public int Id { get; set; }

        public int ApplicationUserId { get; set; }

        public string ApplicationUserEmail { get; set; }

        public DeleteRestaurantCommand(int id)
        {
            this.Id = id;
        }
    }
}
