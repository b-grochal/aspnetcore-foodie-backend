using AutoMapper;
using Foodie.Meals.Commands.Restaurants;
using Foodie.Meals.Models;
using Foodie.Meals.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Handlers.Restaurants
{
    public class CreateRestaurantHandler : IRequestHandler<CreateRestaurantCommand>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly IMapper mapper;

        public CreateRestaurantHandler(IRestaurantsRepository restaurantsRepository, IMapper mapper)
        {
            this.restaurantsRepository = restaurantsRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = mapper.Map<Restaurant>(request);
            await restaurantsRepository.CreateRestaurant(restaurant);
            return new Unit();
        }
    }
}
