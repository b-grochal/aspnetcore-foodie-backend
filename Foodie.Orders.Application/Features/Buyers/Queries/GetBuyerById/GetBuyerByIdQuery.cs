using Foodie.Common.Results;
using MediatR;

namespace Foodie.Orders.Application.Features.Buyers.Queries.GetBuyerById
{
    public class GetBuyerByIdQuery : IRequest<Result<GetBuyerByIdQueryResponse>>
    {
        public int Id { get; }

        public GetBuyerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
