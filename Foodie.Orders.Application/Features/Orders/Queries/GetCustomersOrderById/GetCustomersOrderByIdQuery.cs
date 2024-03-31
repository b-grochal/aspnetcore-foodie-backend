using Foodie.Common.Application.Requests.Abstractions;
using Foodie.Common.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrderById
{
    public class GetCustomersOrderByIdQuery : IRequest<Result<GetCustomersOrderByIdQueryResponse>>, IApplicationUserIdRequest
    {
        public int Id { get; }

        [JsonIgnore]
        public int ApplicationUserId { get; set; }

        public GetCustomersOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
