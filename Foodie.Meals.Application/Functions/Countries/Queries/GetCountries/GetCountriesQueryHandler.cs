using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Countries.Queries.GetCountries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, GetCountriesQueryResponse>
    {
        private readonly ICountriesRepository countriesRepository;
        private readonly IMapper mapper;

        public GetCountriesQueryHandler(ICountriesRepository countriesRepository, IMapper mapper)
        {
            this.countriesRepository = countriesRepository;
            this.mapper = mapper;
        }

        public async Task<GetCountriesQueryResponse> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var result = await countriesRepository.GetAllAsync(request.PageNumber, request.PageSize, request.Name);

            return new GetCountriesQueryResponse
            {
                TotalCount = result.TotalCount,
                PageSize = request.PageSize,
                CurrentPage = request.PageNumber,
                TotalPages = (int)Math.Ceiling(result.TotalCount / (double)request.PageSize),
                Countries = mapper.Map<IEnumerable<CountryDto>>(result.Items),
                Name = request.Name
            };
        }
    }
}
