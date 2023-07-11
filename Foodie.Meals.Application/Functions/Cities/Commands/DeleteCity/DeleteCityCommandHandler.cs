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

        public DeleteCityCommandHandler(ICitiesRepository citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public async Task<DeleteCityCommandResponse> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await citiesRepository.GetByIdAsync(request.Id);

            if (city == null)
                throw new CityNotFoundException(request.Id);

            await citiesRepository.DeleteAsync(city);

            return new DeleteCityCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
