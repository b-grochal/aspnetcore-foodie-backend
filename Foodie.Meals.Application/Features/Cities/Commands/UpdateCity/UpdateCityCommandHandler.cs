using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Application.Features.Cities.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, Result<UpdateCityCommandResponse>>
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCityCommandHandler(ICitiesRepository citiesRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _citiesRepository = citiesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<UpdateCityCommandResponse>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _citiesRepository.GetByIdAsync(request.Id);

            if (city is null)
                return Result.Failure<UpdateCityCommandResponse>(CitiesErrors.CityNotFoundById(request.Id));

            var editedCity = _mapper.Map(request, city);
            await _citiesRepository.UpdateAsync(editedCity);
            await _unitOfWork.CommitChangesAsync(request.User, cancellationToken);

            return _mapper.Map<UpdateCityCommandResponse>(editedCity);
        }
    }
}
