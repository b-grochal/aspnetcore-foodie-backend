using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Queries.GetLocationById
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, LocationDetailsResponse>
    {
        private readonly ILocationsRepository locationsRepository;
        private readonly IMapper mapper;

        public GetLocationByIdQueryHandler(ILocationsRepository locationsRepository, IMapper mapper)
        {
            this.locationsRepository = locationsRepository;
            this.mapper = mapper;
        }

        public async Task<LocationDetailsResponse> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var location = await locationsRepository.GetByIdAsync(request.LocationId);
            return mapper.Map<LocationDetailsResponse>(location);
        }
    }
}
