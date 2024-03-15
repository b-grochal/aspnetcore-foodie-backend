using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlerById
{
    public class GetOrderHandlerByIdQuery : IRequest<Result<GetOrderHandlerByIdQueryResponse>>
    {
        public int Id { get; }

        public GetOrderHandlerByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
