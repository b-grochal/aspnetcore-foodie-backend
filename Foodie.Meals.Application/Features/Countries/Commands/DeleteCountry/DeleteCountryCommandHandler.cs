using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Application.Features.Countries.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Result<DeleteCountryCommandResponse>>
    {
        private readonly ICountriesRepository _countriesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCountryCommandHandler(ICountriesRepository countriesRepository, IUnitOfWork unitOfWork)
        {
            _countriesRepository = countriesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DeleteCountryCommandResponse>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _countriesRepository.GetByIdAsync(request.Id);

            if (country is null)
                return Result.Failure<DeleteCountryCommandResponse>(CountriesErrors.CountryNotFoundById(request.Id));

            await _countriesRepository.DeleteAsync(country);

            await _unitOfWork.CommitChangesAsync(request.User, cancellationToken);

            return new DeleteCountryCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
