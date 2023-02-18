using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Commands.SetInDeliveryOrderStatus
{
    public class SetInDeliveryOrderStatusCommand : IRequest
    {
        public int OrderId { get; set; }
        public int? LocationId { get; set; }

        public SetInDeliveryOrderStatusCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}
