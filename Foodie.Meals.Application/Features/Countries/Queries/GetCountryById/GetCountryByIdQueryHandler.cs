using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Countries.Queries.GetCountryById
{
    public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, GetCountryByIdQueryResponse>
    {
        private readonly ICountriesRepository countriesRepository;
        private readonly IMapper mapper;

        public GetCountryByIdQueryHandler(ICountriesRepository countriesRepository, IMapper mapper)
        {
            this.countriesRepository = countriesRepository;
            this.mapper = mapper;
        }

        public async Task<GetCountryByIdQueryResponse> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await countriesRepository.GetByIdAsync(request.Id);

            if (country == null)
                throw new CountryNotFoundException(request.Id);

            return mapper.Map<GetCountryByIdQueryResponse>(country);
        }
    }
}
