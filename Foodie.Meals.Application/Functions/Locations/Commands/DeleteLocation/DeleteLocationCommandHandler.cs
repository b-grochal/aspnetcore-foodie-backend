using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, DeleteLocationCommandResponse>
    {
        private readonly ILocationsRepository locationsRepository;

        public DeleteLocationCommandHandler(ILocationsRepository locationsRepository)
        {
            this.locationsRepository = locationsRepository;
        }

        public async Task<DeleteLocationCommandResponse> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var locationToDelete = await locationsRepository.GetByIdAsync(request.LocationId);

            if (locationToDelete == null)
                throw new LocationNotFoundException(request.LocationId);

            await locationsRepository.DeleteAsync(locationToDelete);
            
            return new DeleteLocationCommandResponse
            {
                Id = request.LocationId
            };
        }
    }
}
