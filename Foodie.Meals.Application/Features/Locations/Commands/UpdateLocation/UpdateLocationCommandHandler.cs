using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, UpdateLocationCommandResponse>
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

        public async Task<UpdateLocationCommandResponse> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _locationsRepository.GetByIdAsync(request.Id);

            if (location == null)
                throw new LocationNotFoundException(request.Id);

            var editedLocation = _mapper.Map(request, location);
            await _locationsRepository.UpdateAsync(editedLocation);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UpdateLocationCommandResponse>(editedLocation);
        }
    }
}
