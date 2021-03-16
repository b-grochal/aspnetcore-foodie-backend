using AutoMapper;
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
    public class EditRestaurantHandler : IRequestHandler<EditRestaurantCommand>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly IMapper mapper;

        public EditRestaurantHandler(IRestaurantsRepository restaurantRepository, IMapper mapper)
        {
            this.restaurantsRepository = restaurantRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(EditRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetRestaurant(request.RestaurantId);
            var editedRestaurant = mapper.Map(request, restaurant);
            await restaurantsRepository.EditRestaurant(editedRestaurant);
            return new Unit();
        }
    }
}
