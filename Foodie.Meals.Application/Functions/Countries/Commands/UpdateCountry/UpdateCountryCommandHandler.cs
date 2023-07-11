using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, UpdateCountryCommandResponse>
    {
        private readonly ICountriesRepository countriesRepository;
        private readonly IMapper mapper;

        public UpdateCountryCommandHandler(ICountriesRepository countriesRepository, IMapper mapper)
        {
            this.countriesRepository = countriesRepository;
            this.mapper = mapper;
        }

        public async Task<UpdateCountryCommandResponse> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await countriesRepository.GetByIdAsync(request.Id);

            if (country == null)
                throw new CountryNotFoundException(request.Id);

            country = mapper.Map(request, country);
            await countriesRepository.UpdateAsync(country);
            return mapper.Map<UpdateCountryCommandResponse>(country);
        }
    }
}
