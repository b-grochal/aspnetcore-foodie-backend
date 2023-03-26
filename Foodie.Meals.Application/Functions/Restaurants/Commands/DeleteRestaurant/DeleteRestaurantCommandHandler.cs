using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, DeleteRestaurantCommandResponse>
    {
        private readonly IRestaurantsRepository restaurantRepository;

        public DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public async Task<DeleteRestaurantCommandResponse> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurantToDelete = await restaurantRepository.GetByIdAsync(request.Id);

            if (restaurantToDelete == null)
                throw new RestaurantNotFoundException(request.Id);

            await restaurantRepository.DeleteAsync(restaurantToDelete);

            return new DeleteRestaurantCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
