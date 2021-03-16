using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Commands.OrderHandlers
{
    public class DeleteOrderHandlerCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteOrderHandlerCommand(string id)
        {
            this.Id = id;
        }
    }
}
