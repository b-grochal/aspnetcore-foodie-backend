using Foodie.Common.Application.Requests.Abstractions;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrderById
{
    public class GetCustomersOrderByIdQuery : IRequest<GetCustomersOrderByIdQueryResponse>, IApplicationUserIdRequest
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
