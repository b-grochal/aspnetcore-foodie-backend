using Foodie.Common.Application.Requests.Abstractions;
using MediatR;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : ILocationRequest, IRequest<GetOrderByIdQueryResponse>
    {
        public int Id { get; }
        public int LocationId { get; set; }

        public GetOrderByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
