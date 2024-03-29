﻿using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, UpdateLocationCommandResponse>
    {
        private readonly ILocationsRepository locationsRepository;
        private readonly IMapper mapper;

        public UpdateLocationCommandHandler(ILocationsRepository locationsRepository, IMapper mapper)
        {
            this.locationsRepository = locationsRepository;
            this.mapper = mapper;
        }

        public async Task<UpdateLocationCommandResponse> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await locationsRepository.GetByIdAsync(request.Id);

            if (location == null)
                throw new LocationNotFoundException(request.Id);

            var editedLocation = mapper.Map(request, location);
            await locationsRepository.UpdateAsync(editedLocation);

            return mapper.Map<UpdateLocationCommandResponse>(editedLocation);
        }
    }
}
