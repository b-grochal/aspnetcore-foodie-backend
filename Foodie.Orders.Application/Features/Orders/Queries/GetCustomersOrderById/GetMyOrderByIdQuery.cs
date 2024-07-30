using Foodie.Common.Application.Requests.Interfaces;
using Foodie.Common.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrderById
{
    public class GetMyOrderByIdQuery : IRequest<Result<GetMyOrderByIdQueryResponse>>, IApplicationUserIdRequest
    {
        public int Id { get; }

        [JsonIgnore]
        public int ApplicationUserId { get; set; }

        public GetMyOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
