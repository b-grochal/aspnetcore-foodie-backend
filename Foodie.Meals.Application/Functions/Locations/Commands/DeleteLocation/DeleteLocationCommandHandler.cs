using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, DeleteLocationCommandResponse>
    {
        private readonly ILocationsRepository _locationsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLocationCommandHandler(ILocationsRepository locationsRepository, IUnitOfWork unitOfWork)
        {
            _locationsRepository = locationsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteLocationCommandResponse> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var locationToDelete = await _locationsRepository.GetByIdAsync(request.Id);

            if (locationToDelete == null)
                throw new LocationNotFoundException(request.Id);

            await _locationsRepository.DeleteAsync(locationToDelete);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteLocationCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
