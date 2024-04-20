using AutoMapper;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantLocations
{
    public class GetRestaurantLocationsQueryHandler : IRequestHandler<GetRestaurantLocationsQuery, Result<GetRestaurantLocationsQueryResponse>>
    {
        private readonly ILocationsRepository locationsRepository;
        private readonly IMapper mapper;

        public GetRestaurantLocationsQueryHandler(ILocationsRepository locationsRepository, IMapper mapper)
        {
            this.locationsRepository = locationsRepository;
            this.mapper = mapper;
        }

        public async Task<Result<GetRestaurantLocationsQueryResponse>> Handle(GetRestaurantLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await locationsRepository.GetAllAsync(request.Id, request.CityId);

            return new GetRestaurantLocationsQueryResponse
            {
                RestaurantLocations = mapper.Map<IEnumerable<RestaurantLocationDto>>(locations)
            };
        }
    }
}
