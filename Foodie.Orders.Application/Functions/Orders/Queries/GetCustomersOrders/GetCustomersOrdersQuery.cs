using Foodie.Common.Application.Queries;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrders
{
    public class GetCustomersOrdersQuery : PagedQuery, IRequest<GetCustomersOrdersQueryResponse>
    {
        [JsonIgnore]
        public int CustomerId { get; set; }
        public int? OrderStatusId { get; set; }
        public string ContractorName { get; set; }
    }
}
