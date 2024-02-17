using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, UpdateCityCommandResponse>
    {
        private readonly ICitiesRepository citiesRepository;
        private readonly IMapper mapper;

        public UpdateCityCommandHandler(ICitiesRepository citiesRepository, IMapper mapper)
        {
            this.citiesRepository = citiesRepository;
            this.mapper = mapper;
        }

        public async Task<UpdateCityCommandResponse> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await citiesRepository.GetByIdAsync(request.Id);

            if (city == null)
                throw new CityNotFoundException(request.Id);

            var editedCity = mapper.Map(request, city);
            await citiesRepository.UpdateAsync(editedCity);
            return mapper.Map<UpdateCityCommandResponse>(editedCity);
        }
    }
}
