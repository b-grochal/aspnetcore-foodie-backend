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
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, GetLocationsQueryResponse>
    {
        private readonly ILocationsRepository locationsRepository;
        private readonly IMapper mapper;

        public GetLocationsQueryHandler(ILocationsRepository locationsRepository, IMapper mapper)
        {
            this.locationsRepository = locationsRepository;
            this.mapper = mapper;
        }

        public async Task<GetLocationsQueryResponse> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var result = await locationsRepository.GetAllAsync(request.PageNumber, request.PageSize, request.RestaurantId, request.CityId);

            return new GetLocationsQueryResponse
            {
                TotalCount = result.TotalCount,
                PageSize = request.PageSize,
                CurrentPage = request.PageNumber,
                TotalPages = (int)Math.Ceiling(result.TotalCount / (double)request.PageSize),
                Locations = mapper.Map<IEnumerable<LocationDto>>(result.Items),
                RestaurantId = request.RestaurantId,
                CityId = request.CityId
            };
        }
    }
}
