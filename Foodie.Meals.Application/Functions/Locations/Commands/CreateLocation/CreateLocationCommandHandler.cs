using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Commands.CreateLocation
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, CreateLocationCommandResponse>
    {
        private readonly ILocationsRepository locationsRepository;
        private readonly IMapper mapper;

        public CreateLocationCommandHandler(ILocationsRepository locationsRepository, IMapper mapper)
        {
            this.locationsRepository = locationsRepository;
            this.mapper = mapper;
        }

        public async Task<CreateLocationCommandResponse> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = mapper.Map<Location>(request);
            await locationsRepository.CreateAsync(location);
            return mapper.Map<CreateLocationCommandResponse>(location);
        }
    }
}
