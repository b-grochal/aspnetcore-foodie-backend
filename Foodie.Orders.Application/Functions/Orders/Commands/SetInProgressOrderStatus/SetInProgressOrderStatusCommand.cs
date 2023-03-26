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
        public int Id { get; set; }
        public int? LocationId { get; set; }

        public SetInProgressOrderStatusCommand(int id)
        {
            Id = id;
        }
    }
}
