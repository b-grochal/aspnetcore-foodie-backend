using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, DeleteCountryCommandResponse>
    {
        private readonly ICountriesRepository countriesRepository;

        public DeleteCountryCommandHandler(ICountriesRepository countriesRepository)
        {
            this.countriesRepository = countriesRepository;
        }

        public async Task<DeleteCountryCommandResponse> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await countriesRepository.GetByIdAsync(request.Id);

            if (country == null)
                throw new CountryNotFoundException(request.Id);

            await countriesRepository.DeleteAsync(country);

            return new DeleteCountryCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
