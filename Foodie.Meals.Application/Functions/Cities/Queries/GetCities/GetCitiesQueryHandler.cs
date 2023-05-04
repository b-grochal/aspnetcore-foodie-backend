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
            var result = await citiesRepository.GetAllAsync(request.PageNumber, request.PageSize, request.Name, request.Country);

            return new GetCitiesQueryResponse
            {
                TotalCount = result.TotalCount,
                PageSize = request.PageSize,
                CurrentPage = request.PageNumber,
                TotalPages = (int)Math.Ceiling(result.TotalCount / (double)request.PageSize),
                Cities = mapper.Map<IEnumerable<CityDto>>(result.Items),
                Name = request.Name,
                Country = request.Country
            };
        }
    }
}
