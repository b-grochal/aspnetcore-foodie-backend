using AutoMapper;
using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Buyers;
using Foodie.Orders.Application.Features.Buyers.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Buyers.Queries.GetBuyerById
{
    public class GetBuyerByIdQueryHandler : IRequestHandler<GetBuyerByIdQuery, Result<GetBuyerByIdQueryResponse>>
    {
        private readonly IBuyersQueries _buyerQueries;
        private readonly IMapper _mapper;

        public GetBuyerByIdQueryHandler(IBuyersQueries buyerQueries, IMapper mapper)
        {
            _buyerQueries = buyerQueries;
            _mapper = mapper;
        }

        public async Task<Result<GetBuyerByIdQueryResponse>> Handle(GetBuyerByIdQuery request, CancellationToken cancellationToken)
        {
            var buyer = await _buyerQueries.GetByIdAsync(request.Id);

            if (buyer is null)
                return Result.Failure<GetBuyerByIdQueryResponse>(BuyerErrors.BuyerNotFoundById(request.Id));

            return _mapper.Map<GetBuyerByIdQueryResponse>(buyer);
        }
    }
}
