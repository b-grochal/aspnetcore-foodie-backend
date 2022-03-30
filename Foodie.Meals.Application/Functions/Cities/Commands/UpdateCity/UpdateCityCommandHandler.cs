using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand>
    {
        private readonly ICitiesRepository citiesRepository;
        private readonly IMapper mapper;

        public UpdateCityCommandHandler(ICitiesRepository citiesRepository, IMapper mapper)
        {
            this.citiesRepository = citiesRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await citiesRepository.GetByIdAsync(request.CityId);

            if (city == null)
                throw new CityNotFoundException(request.CityId);

            var editedCity = mapper.Map(request, city);
            await citiesRepository.UpdateAsync(editedCity);
            return new Unit();
        }
    }
}
