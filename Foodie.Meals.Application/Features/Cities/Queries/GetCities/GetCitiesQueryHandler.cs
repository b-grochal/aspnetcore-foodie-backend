using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Queries.GetCities
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, GetCitiesQueryResponse>
    {
        private readonly ICitiesRepository citiesRepository;
        private readonly IMapper mapper;

        public GetCitiesQueryHandler(ICitiesRepository citiesRepository, IMapper mapper)
        {
            this.citiesRepository = citiesRepository;
            this.mapper = mapper;
        }

        public async Task<GetCitiesQueryResponse> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            var result = await citiesRepository.GetAllAsync(request.PageNumber, request.PageSize, request.Name, request.CountryId);

            return new GetCitiesQueryResponse
            {
                TotalCount = result.TotalCount,
                PageSize = result.PageSize,
                Page = result.Page,
                TotalPages = result.TotalPages,
                Items = mapper.Map<IEnumerable<CityDto>>(result.Items),
                Name = request.Name,
                CountryId = request.CountryId
            };
        }
    }
}
