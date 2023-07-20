using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Commands.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CreateCityCommandResponse>
    {
        private readonly ICitiesRepository citiesRepository;
        private readonly IMapper mapper;

        public CreateCityCommandHandler(ICitiesRepository citiesRepository, IMapper mapper)
        {
            this.citiesRepository = citiesRepository;
            this.mapper = mapper;
        }

        public async Task<CreateCityCommandResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var city = mapper.Map<City>(request);
            await citiesRepository.CreateAsync(city);
            return mapper.Map<CreateCityCommandResponse>(city);
        }
    }
}
