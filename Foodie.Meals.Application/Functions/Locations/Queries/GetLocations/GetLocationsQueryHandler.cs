using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Queries.GetLocations
{
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, LocationsListResponse>
    {
        private readonly ILocationsRepository locationsRepository;
        private readonly IMapper mapper;

        public GetLocationsQueryHandler(ILocationsRepository locationsRepository, IMapper mapper)
        {
            this.locationsRepository = locationsRepository;
            this.mapper = mapper;
        }

        public async Task<LocationsListResponse> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await locationsRepository.GetAllAsync(request.PageNumber, request.PageSize, request.RestaurantId, request.CityId);

            return new LocationsListResponse
            {
                TotalCount = locations.TotalCount,
                PageSize = locations.PageSize,
                CurrentPage = locations.CurrentPage,
                TotalPages = (int)Math.Ceiling(locations.TotalCount / (double)locations.PageSize),
                Locations = mapper.Map<IEnumerable<LocationResponse>>(locations),
                RestaurantId = request.RestaurantId.Value,
                CityId = request.CityId.Value
            };
        }
    }
}
