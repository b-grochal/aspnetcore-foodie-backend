using MediatR;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlerById
{
    public class GetOrderHandlerByIdQuery : IRequest<GetOrderHandlerByIdQueryResponse>
    {
        public int Id { get; }

        public GetOrderHandlerByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
