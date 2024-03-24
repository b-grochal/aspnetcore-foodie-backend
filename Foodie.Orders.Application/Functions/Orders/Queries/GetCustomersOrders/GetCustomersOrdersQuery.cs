using Foodie.Common.Application.Requests.Abstractions;
using Foodie.Common.Application.Requests.Queries.Abstractions;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrders
{
    public class GetCustomersOrdersQuery : PagedQuery, IRequest<GetCustomersOrdersQueryResponse>, IApplicationUserIdRequest
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }
        public int? OrderStatusId { get; set; }
        public string ContractorName { get; set; }
    }
}
