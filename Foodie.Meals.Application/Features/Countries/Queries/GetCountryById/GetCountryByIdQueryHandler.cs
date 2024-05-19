using AutoMapper;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Application.Features.Countries.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Countries.Queries.GetCountryById
{
    public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, Result<GetCountryByIdQueryResponse>>
    {
        private readonly ICountriesRepository countriesRepository;
        private readonly IMapper mapper;

        public GetCountryByIdQueryHandler(ICountriesRepository countriesRepository, IMapper mapper)
        {
            this.countriesRepository = countriesRepository;
            this.mapper = mapper;
        }

        public async Task<Result<GetCountryByIdQueryResponse>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await countriesRepository.GetByIdAsync(request.Id);

            if (country is null)
                return Result.Failure<GetCountryByIdQueryResponse>(CountriesErrors.CountryNotFoundById(request.Id));

            return mapper.Map<GetCountryByIdQueryResponse>(country);
        }
    }
}
