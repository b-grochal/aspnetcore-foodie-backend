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

namespace Foodie.Meals.Application.Functions.Cities.Commands.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, DeleteCityCommandResponse>
    {
        private readonly ICitiesRepository citiesRepository;
        private readonly IMapper mapper;

        public DeleteCityCommandHandler(ICitiesRepository citiesRepository, IMapper mapper)
        {
            this.citiesRepository = citiesRepository;
            this.mapper = mapper;
        }

        public async Task<DeleteCityCommandResponse> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var cityToDelete = await citiesRepository.GetByIdAsync(request.CityId);

            if (cityToDelete == null)
                throw new CityNotFoundException(request.CityId);

            await citiesRepository.DeleteAsync(cityToDelete);

            return new DeleteCityCommandResponse
            {
                CityId = request.CityId
            };
        }
    }
}
