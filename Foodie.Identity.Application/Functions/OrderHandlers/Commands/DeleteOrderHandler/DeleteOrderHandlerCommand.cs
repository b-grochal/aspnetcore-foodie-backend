using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.DeleteOrderHandler
{
    public class DeleteOrderHandlerCommand : IRequest<DeleteOrderHandlerCommandResponse>
    {
        public string Id { get; set; }

        public DeleteOrderHandlerCommand(string id)
        {
            this.Id = id;
        }
    }
}
