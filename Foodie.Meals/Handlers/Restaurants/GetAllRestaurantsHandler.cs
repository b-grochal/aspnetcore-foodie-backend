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
    public class GetAllRestaurantsHandler : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantResponse>>
    {
        private readonly IRestaurantsRepository restaurantRepository;
        private readonly IMapper mapper;

        public GetAllRestaurantsHandler(IRestaurantsRepository restaurantRepository, IMapper mapper)
        {
            this.restaurantRepository = restaurantRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RestaurantResponse>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var restaurants = await restaurantRepository.GetRestaurants();
            return mapper.Map<IEnumerable<RestaurantResponse>>(restaurants);
        }
    }
}
