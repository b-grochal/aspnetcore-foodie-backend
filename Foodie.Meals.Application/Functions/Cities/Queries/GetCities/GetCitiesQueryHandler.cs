using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var cities = await citiesRepository.GetAllAsync(request.PageNumber, request.PageSize, request.Name, request.Country);

            return new GetCitiesQueryResponse
            {
                TotalCount = cities.TotalCount,
                PageSize = cities.PageSize,
                CurrentPage = cities.CurrentPage,
                TotalPages = (int)Math.Ceiling(cities.TotalCount / (double)cities.PageSize),
                Cities = mapper.Map<IEnumerable<CityDto>>(cities),
                Name = request.Name,
                Country = request.Country
            };
        }
    }
}
