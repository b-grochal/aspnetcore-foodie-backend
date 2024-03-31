using AutoMapper;
using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Buyers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Buyers.Queries.GetBuyers
{
    public class GetBuyersQueryHandler : IRequestHandler<GetBuyersQuery, Result<GetBuyersQueryResponse>>
    {
        private readonly IBuyersQueries _buyerQueries;
        private readonly IMapper _mapper;

        public GetBuyersQueryHandler(IBuyersQueries buyerQueries, IMapper mapper)
        {
            _buyerQueries = buyerQueries;
            _mapper = mapper;
        }

        public async Task<Result<GetBuyersQueryResponse>> Handle(GetBuyersQuery request, CancellationToken cancellationToken)
        {
            var buyers = await _buyerQueries.GetAllAsync(request.PageNumber, request.PageSize, request.Email);

            return new GetBuyersQueryResponse
            {
                TotalCount = buyers.TotalCount,
                PageSize = buyers.PageSize,
                Page = buyers.Page,
                TotalPages = (int)Math.Ceiling(buyers.TotalCount / (double)buyers.PageSize),
                Items = _mapper.Map<IEnumerable<BuyerDto>>(buyers),
                Email = request.Email
            };
        }
    }
}
