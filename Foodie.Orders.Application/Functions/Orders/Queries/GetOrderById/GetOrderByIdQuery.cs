﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<GetOrderByIdQueryResponse>
    {
        public int OrderId { get; }

        public GetOrderByIdQuery(int orderId)
        {
            this.OrderId = orderId;
        }
    }
}
