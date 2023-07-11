using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CreateCountryCommandResponse>
    {
        private readonly ICountriesRepository countriesRepository;
        private readonly IMapper mapper;

        public CreateCountryCommandHandler(ICountriesRepository countriesRepository, IMapper mapper)
        {
            this.countriesRepository = countriesRepository;
            this.mapper = mapper;
        }

        public async Task<CreateCountryCommandResponse> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = mapper.Map<Country>(request);
            await countriesRepository.CreateAsync(country);
            return mapper.Map<CreateCountryCommandResponse>(country);
        }
    }
}
