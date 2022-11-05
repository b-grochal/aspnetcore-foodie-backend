using AutoMapper;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Buyers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Buyers.Queries.GetBuyerById
{
    public class GetBuyerByIdQueryHandler : IRequestHandler<GetBuyerByIdQuery, GetBuyerByIdQueryResponse>
    {
        private readonly IBuyerQueries _buyerQueries;
        private readonly IMapper _mapper;

        public GetBuyerByIdQueryHandler(IBuyerQueries buyerQueries, IMapper mapper)
        {
            _buyerQueries = buyerQueries;
            _mapper = mapper;
        }

        public async Task<GetBuyerByIdQueryResponse> Handle(GetBuyerByIdQuery request, CancellationToken cancellationToken)
        {
            var buyer = await _buyerQueries.GetByIdAsync(request.BuyerId);

            if (buyer == null)
                throw new NotImplementedException();

            return _mapper.Map<GetBuyerByIdQueryResponse>(buyer);
        }
    }
}
