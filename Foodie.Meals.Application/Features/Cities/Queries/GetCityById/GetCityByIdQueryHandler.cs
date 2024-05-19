using AutoMapper;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Application.Features.Cities.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Queries.GetCityById
{
    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, Result<GetCityByIdQueryResponse>>
    {
        private readonly ICitiesRepository citiesRepository;
        private readonly IMapper mapper;

        public GetCityByIdQueryHandler(ICitiesRepository citiesRepository, IMapper mapper)
        {
            this.citiesRepository = citiesRepository;
            this.mapper = mapper;
        }

        public async Task<Result<GetCityByIdQueryResponse>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await citiesRepository.GetByIdAsync(request.Id);

            if (city is null)
                return Result.Failure<GetCityByIdQueryResponse>(CitiesErrors.CityNotFoundById(request.Id));

            return mapper.Map<GetCityByIdQueryResponse>(city);
        }
    }
}
