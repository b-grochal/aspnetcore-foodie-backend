﻿using Foodie.Common.Application.Queries;
using MediatR;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetOrders
{
    public class GetOrdersQuery : PagedQuery, IRequest<GetOrdersQueryResponse>
    {
        public string BuyerEmail { get; set; }
        public string OrderStatusName { get; set; } // TODO: Change to order status id
        public string ContractorName { get; set; } // TODO: Change to contractor id
        public int? LocationId { get; set; }
    }
}
