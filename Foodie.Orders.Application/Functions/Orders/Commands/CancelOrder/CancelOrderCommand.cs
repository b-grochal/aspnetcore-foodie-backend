using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Commands.CancelOrder
{
    public class CancelOrderCommand : IRequest
    {
        public int Id { get; set; }
        public int? LocationId { get; set; }

        public CancelOrderCommand(int id)
        {
            Id = id;
        }
    }
}
