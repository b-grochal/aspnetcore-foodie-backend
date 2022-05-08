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
    public class GetRestaurantLocationsQueryHandler : IRequestHandler<GetRestaurantLocationsQuery, IEnumerable<RestaurantLocationResponse>>
    {
        private readonly ILocationsRepository locationsRepository;
        private readonly IMapper mapper;

        public GetRestaurantLocationsQueryHandler(ILocationsRepository locationsRepository, IMapper mapper)
        {
            this.locationsRepository = locationsRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RestaurantLocationResponse>> Handle(GetRestaurantLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await locationsRepository.GetAllAsync(request.RestaurantId, request.CityId);
            return mapper.Map<IEnumerable<RestaurantLocationResponse>>(locations);
        }
    }
}
