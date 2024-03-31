using AutoMapper;
using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Contractors;
using Foodie.Orders.Application.Features.Contractors.Errors;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Contractors.Queries.GetContractorById
{
    public class GetContractorByIdQueryHandler : IRequestHandler<GetContractorByIdQuery, Result<GetContractorByIdQueryResponse>>
    {
        private readonly IContractorsQueries _contractorsQueries;
        private readonly IMapper _mapper;

        public GetContractorByIdQueryHandler(IContractorsQueries contractorsQueries, IMapper mapper)
        {
            _contractorsQueries = contractorsQueries;
            _mapper = mapper;
        }

        public async Task<Result<GetContractorByIdQueryResponse>> Handle(GetContractorByIdQuery request, CancellationToken cancellationToken)
        {
            var contractor = await _contractorsQueries.GetByIdAsync(request.Id);

            if (contractor is null)
                return Result.Failure<GetContractorByIdQueryResponse>(ContractorErrors.ContractorNotFoundById(request.Id));

            return _mapper.Map<GetContractorByIdQueryResponse>(contractor);
        }
    }
}
