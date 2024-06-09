using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Commands.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Result<CreateCityCommandResponse>>
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCityCommandHandler(ICitiesRepository citiesRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _citiesRepository = citiesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CreateCityCommandResponse>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var city = _mapper.Map<City>(request);
            await _citiesRepository.CreateAsync(city);
            await _unitOfWork.CommitChangesAsync(request.ApplicationUserId, request.ApplicationUserEmail, GetType().Name, cancellationToken);
            return _mapper.Map<CreateCityCommandResponse>(city);
        }
    }
}
