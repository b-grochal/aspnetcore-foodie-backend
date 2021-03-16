using Foodie.Meals.Commands.Restaurants;
using Foodie.Meals.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Handlers.Restaurants
{
    public class DeleteRestaurantHandler : IRequestHandler<DeleteRestaurantCommand>
    {
        private readonly IRestaurantsRepository restaurantRepository;

        public DeleteRestaurantHandler(IRestaurantsRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public async Task<Unit> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            await restaurantRepository.DeleteRestaurant(request.RestaurantId);
            return new Unit();
        }
    }
}
