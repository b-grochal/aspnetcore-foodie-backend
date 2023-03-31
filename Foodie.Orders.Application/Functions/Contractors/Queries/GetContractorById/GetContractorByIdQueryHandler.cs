using AutoMapper;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Contractors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Contractors.Queries.GetContractorById
{
    public class GetContractorByIdQueryHandler : IRequestHandler<GetContractorByIdQuery, GetContractorByIdQueryResponse>
    {
        private readonly IContractorsQueries _contractorsQueries;
        private readonly IMapper _mapper;

        public GetContractorByIdQueryHandler(IContractorsQueries contractorsQueries, IMapper mapper)
        {
            _contractorsQueries = contractorsQueries;
            _mapper = mapper;
        }

        public async Task<GetContractorByIdQueryResponse> Handle(GetContractorByIdQuery request, CancellationToken cancellationToken)
        {
            var contractor = await _contractorsQueries.GetByIdAsync(request.Id);

            if (contractor == null)
                throw new NotImplementedException();

            return _mapper.Map<GetContractorByIdQueryResponse>(contractor);
        }
    }
}
