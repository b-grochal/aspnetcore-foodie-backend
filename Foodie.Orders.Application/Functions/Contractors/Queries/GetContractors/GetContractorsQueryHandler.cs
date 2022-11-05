using AutoMapper;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Contractors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Contractors.Queries.GetContractors
{
    public class GetContractorsQueryHandler : IRequestHandler<GetContractorsQuery, GetContractorsQueryResponse>
    {
        private readonly IContractorsQueries _contractorsQueries;
        private readonly IMapper _mapper;

        public GetContractorsQueryHandler(IContractorsQueries contractorsQueries, IMapper mapper)
        {
            _contractorsQueries = contractorsQueries;
            _mapper = mapper;
        }

        public async Task<GetContractorsQueryResponse> Handle(GetContractorsQuery request, CancellationToken cancellationToken)
        {
            var contractors = await _contractorsQueries.GetAllAsync(request.PageNumber, request.PageSize, request.RestaurantId, request.LocationId, request.CityId);

            return new GetContractorsQueryResponse
            {
                TotalCount = contractors.TotalCount,
                PageSize = contractors.PageSize,
                CurrentPage = contractors.CurrentPage,
                TotalPages = (int)Math.Ceiling(contractors.TotalCount / (double)contractors.PageSize),
                Contractors = _mapper.Map<IEnumerable<ContractorDto>>(contractors),
                RestaurantId = request.RestaurantId,
                LocationId = request.LocationId,
                CityId = request.CityId
            };
        }
    }
}
