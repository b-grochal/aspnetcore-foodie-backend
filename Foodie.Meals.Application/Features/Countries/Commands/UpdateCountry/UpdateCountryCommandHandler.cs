using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Application.Features.Countries.Errors;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Result<UpdateCountryCommandResponse>>
    {
        private readonly ICountriesRepository _countriesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCountryCommandHandler(ICountriesRepository countriesRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _countriesRepository = countriesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<UpdateCountryCommandResponse>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _countriesRepository.GetByIdAsync(request.Id);

            if (country == null)
                return Result.Failure<UpdateCountryCommandResponse>(CountriesErrors.CountryNotFoundById(request.Id));

            country = _mapper.Map(request, country);
            await _countriesRepository.UpdateAsync(country);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<UpdateCountryCommandResponse>(country);
        }
    }
}
