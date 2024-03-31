using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, DeleteCountryCommandResponse>
    {
        private readonly ICountriesRepository _countriesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCountryCommandHandler(ICountriesRepository countriesRepository, IUnitOfWork unitOfWork)
        {
            _countriesRepository = countriesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteCountryCommandResponse> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _countriesRepository.GetByIdAsync(request.Id);

            if (country == null)
                throw new CountryNotFoundException(request.Id);

            await _countriesRepository.DeleteAsync(country);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteCountryCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
