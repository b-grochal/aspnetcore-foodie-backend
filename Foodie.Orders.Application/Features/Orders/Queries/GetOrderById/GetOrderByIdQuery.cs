using Foodie.Common.Application.Requests.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IApplicationUserLocationRequest, IRequest<Result<GetOrderByIdQueryResponse>>
    {
        public int Id { get; }
        public int LocationId { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
