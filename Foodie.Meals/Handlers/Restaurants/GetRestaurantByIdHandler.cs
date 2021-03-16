using AutoMapper;
using Foodie.Meals.Queries.Restaurants;
using Foodie.Meals.Repositories.Interfaces;
using Foodie.Meals.Responses.Restaurants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Handlers.Restaurants
{
    public class GetRestaurantByIdHandler : IRequestHandler<GetRestaurantByIdQuery, RestaurantResponse>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly IMapper mapper;

        public GetRestaurantByIdHandler(IRestaurantsRepository restaurantsRepository, IMapper mapper)
        {
            this.restaurantsRepository = restaurantsRepository;
            this.mapper = mapper;
        }

        public async Task<RestaurantResponse> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            var restaurants = await restaurantsRepository.GetRestaurant(request.RestaurantId);
            return mapper.Map<RestaurantResponse>(restaurants);
        }
    }
}
