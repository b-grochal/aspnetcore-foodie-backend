using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, RestaurantDetailsResponse>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly IMapper mapper;

        public GetRestaurantByIdQueryHandler(IRestaurantsRepository restaurantsRepository, IMapper mapper)
        {
            this.restaurantsRepository = restaurantsRepository;
            this.mapper = mapper;
        }

        public async Task<RestaurantDetailsResponse> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);

            if (restaurant == null)
                throw new RestaurantNotFoundException(request.RestaurantId);

            return mapper.Map<RestaurantDetailsResponse>(restaurant);
        }
    }
}
