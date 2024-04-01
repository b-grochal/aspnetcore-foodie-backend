using AutoMapper;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Application.Features.Locations.Errors;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Queries.GetLocationById
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, Result<GetLocationByIdQueryResponse>>
    {
        private readonly ILocationsRepository locationsRepository;
        private readonly IMapper mapper;

        public GetLocationByIdQueryHandler(ILocationsRepository locationsRepository, IMapper mapper)
        {
            this.locationsRepository = locationsRepository;
            this.mapper = mapper;
        }

        public async Task<Result<GetLocationByIdQueryResponse>> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var location = await locationsRepository.GetByIdAsync(request.Id);

            if (location is null)
                return Result.Failure<GetLocationByIdQueryResponse>(LocationsErrors.LocationNotFoundById(request.Id));

            return mapper.Map<GetLocationByIdQueryResponse>(location);
        }
    }
}
