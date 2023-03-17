using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantLocations
{
    public class GetRestaurantLocationsQueryHandler : IRequestHandler<GetRestaurantLocationsQuery, GetRestaurantLocationsQueryResponse>
    {
        private readonly ILocationsRepository locationsRepository;
        private readonly IMapper mapper;

        public GetRestaurantLocationsQueryHandler(ILocationsRepository locationsRepository, IMapper mapper)
        {
            this.locationsRepository = locationsRepository;
            this.mapper = mapper;
        }

        public async Task<GetRestaurantLocationsQueryResponse> Handle(GetRestaurantLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await locationsRepository.GetAllAsync(request.Id, request.CityId);

            return new GetRestaurantLocationsQueryResponse
            {
                RestaurantLocations = mapper.Map<IEnumerable<RestaurantLocationDto>>(locations)
            };
        }
    }
}
