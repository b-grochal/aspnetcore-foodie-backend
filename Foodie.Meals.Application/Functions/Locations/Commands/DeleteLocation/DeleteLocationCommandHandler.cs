using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
    {
        private readonly ILocationsRepository locationsRepository;

        public DeleteLocationCommandHandler(ILocationsRepository locationsRepository)
        {
            this.locationsRepository = locationsRepository;
        }

        public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var locationToDelete = await locationsRepository.GetByIdAsync(request.LocationId);
            await locationsRepository.DeleteAsync(locationToDelete);
            return new Unit();
        }
    }
}
