using AutoMapper;
using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Contractors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Contractors.Queries.GetContractors
{
    public class GetContractorsQueryHandler : IRequestHandler<GetContractorsQuery, Result<GetContractorsQueryResponse>>
    {
        private readonly IContractorsQueries _contractorsQueries;
        private readonly IMapper _mapper;

        public GetContractorsQueryHandler(IContractorsQueries contractorsQueries, IMapper mapper)
        {
            _contractorsQueries = contractorsQueries;
            _mapper = mapper;
        }

        public async Task<Result<GetContractorsQueryResponse>> Handle(GetContractorsQuery request, CancellationToken cancellationToken)
        {
            var contractors = await _contractorsQueries.GetAllAsync(request.PageNumber, request.PageSize, request.RestaurantId, request.LocationId, request.CityId);

            return new GetContractorsQueryResponse
            {
                TotalCount = contractors.TotalCount,
                PageSize = contractors.PageSize,
                Page = contractors.Page,
                TotalPages = (int)Math.Ceiling(contractors.TotalCount / (double)contractors.PageSize),
                Items = _mapper.Map<IEnumerable<ContractorDto>>(contractors),
                RestaurantId = request.RestaurantId,
                LocationId = request.LocationId,
                CityId = request.CityId
            };
        }
    }
}
