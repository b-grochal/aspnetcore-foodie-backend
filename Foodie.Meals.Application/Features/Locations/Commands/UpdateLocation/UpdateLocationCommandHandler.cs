using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Application.Features.Locations.Errors;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Result<UpdateLocationCommandResponse>>
    {
        private readonly ILocationsRepository _locationsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLocationCommandHandler(ILocationsRepository locationsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _locationsRepository = locationsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<UpdateLocationCommandResponse>> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _locationsRepository.GetByIdAsync(request.Id);

            if (location is null)
                return Result.Failure<UpdateLocationCommandResponse>(LocationsErrors.LocationNotFoundById(request.Id));

            var editedLocation = _mapper.Map(request, location);
            await _locationsRepository.UpdateAsync(editedLocation);

            await _unitOfWork.CommitChangesAsync(request.User, cancellationToken);

            return _mapper.Map<UpdateLocationCommandResponse>(editedLocation);
        }
    }
}
