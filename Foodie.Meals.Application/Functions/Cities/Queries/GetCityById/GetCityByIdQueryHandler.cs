using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Queries.GetCityById
{
    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityDetailsResponse>
    {
        private readonly ICitiesRepository citiesRepository;
        private readonly IMapper mapper;

        public GetCityByIdQueryHandler(ICitiesRepository citiesRepository, IMapper mapper)
        {
            this.citiesRepository = citiesRepository;
            this.mapper = mapper;
        }

        public async Task<CityDetailsResponse> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await citiesRepository.GetByIdAsync(request.CityId);

            if (city == null)
                throw new CityNotFoundException(request.CityId);

            return mapper.Map<CityDetailsResponse>(city);
        }
    }
}
