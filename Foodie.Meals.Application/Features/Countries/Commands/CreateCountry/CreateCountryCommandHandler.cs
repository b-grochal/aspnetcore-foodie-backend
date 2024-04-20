using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Result<CreateCountryCommandResponse>>
    {
        private readonly ICountriesRepository _countriesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCountryCommandHandler(ICountriesRepository countriesRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _countriesRepository = countriesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CreateCountryCommandResponse>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = _mapper.Map<Country>(request);
            await _countriesRepository.CreateAsync(country);
            await _unitOfWork.CommitChangesAsync(request.User, cancellationToken);

            return _mapper.Map<CreateCountryCommandResponse>(country);
        }
    }
}
