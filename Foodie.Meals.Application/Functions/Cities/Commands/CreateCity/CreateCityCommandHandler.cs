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

namespace Foodie.Meals.Application.Functions.Cities.Commands.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand>
    {
        private readonly ICitiesRepository citiesRepository;
        private readonly IMapper mapper;

        public CreateCityCommandHandler(ICitiesRepository citiesRepository, IMapper mapper)
        {
            this.citiesRepository = citiesRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var city = mapper.Map<City>(request);
            await citiesRepository.CreateAsync(city);
            return new Unit();
        }
    }
}
