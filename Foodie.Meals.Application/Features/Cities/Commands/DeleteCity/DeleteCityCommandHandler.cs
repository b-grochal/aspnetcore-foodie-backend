using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Application.Features.Cities.Errors;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Commands.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Result<DeleteCityCommandResponse>>
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCityCommandHandler(ICitiesRepository citiesRepository, IUnitOfWork unitOfWork)
        {
            _citiesRepository = citiesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DeleteCityCommandResponse>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _citiesRepository.GetByIdAsync(request.Id);

            if (city is null)
                return Result.Failure<DeleteCityCommandResponse>(CitiesErrors.CityNotFoundById(request.Id));

            await _citiesRepository.DeleteAsync(city);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteCityCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
