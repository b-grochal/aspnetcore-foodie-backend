using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Application.Features.Locations.Errors;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, Result<DeleteLocationCommandResponse>>
    {
        private readonly ILocationsRepository _locationsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLocationCommandHandler(ILocationsRepository locationsRepository, IUnitOfWork unitOfWork)
        {
            _locationsRepository = locationsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DeleteLocationCommandResponse>> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var locationToDelete = await _locationsRepository.GetByIdAsync(request.Id);

            if (locationToDelete is null)
                return Result.Failure<DeleteLocationCommandResponse>(LocationsErrors.LocationNotFoundById(request.Id));

            await _locationsRepository.DeleteAsync(locationToDelete);
            await _unitOfWork.CommitChangesAsync(request.User, cancellationToken);

            return new DeleteLocationCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
