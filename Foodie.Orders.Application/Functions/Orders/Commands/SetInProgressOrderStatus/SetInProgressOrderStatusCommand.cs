using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Commands.SetInProgressOrderStatus
{
    public class SetInProgressOrderStatusCommand : IRequest
    {
        public int OrderId { get; set; }

        public SetInProgressOrderStatusCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}
