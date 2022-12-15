using AutoMapper;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Buyers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Buyers.Queries.GetBuyers
{
    public class GetBuyersQueryHandler : IRequestHandler<GetBuyersQuery, GetBuyersQueryResponse>
    {
        private readonly IBuyersQueries _buyerQueries;
        private readonly IMapper _mapper;

        public GetBuyersQueryHandler(IBuyersQueries buyerQueries, IMapper mapper)
        {
            _buyerQueries = buyerQueries;
            _mapper = mapper;
        }

        public async Task<GetBuyersQueryResponse> Handle(GetBuyersQuery request, CancellationToken cancellationToken)
        {
            var buyers = await _buyerQueries.GetAllAsync(request.PageNumber, request.PageSize, request.Email);

            return new GetBuyersQueryResponse
            {
                TotalCount = buyers.TotalCount,
                PageSize = buyers.PageSize,
                CurrentPage = buyers.CurrentPage,
                TotalPages = (int)Math.Ceiling(buyers.TotalCount / (double)buyers.PageSize),
                Buyers = _mapper.Map<IEnumerable<BuyerDto>>(buyers),
                Email = request.Email
            };
        }
    }
}
