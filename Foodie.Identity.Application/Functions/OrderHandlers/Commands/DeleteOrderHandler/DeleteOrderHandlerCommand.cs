﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.DeleteOrderHandler
{
    public class DeleteOrderHandlerCommand : IRequest<DeleteOrderHandlerCommandResponse>
    {
        public string OrderHandlerId { get; set; }

        public DeleteOrderHandlerCommand(string orderHandlerId)
        {
            this.OrderHandlerId = orderHandlerId;
        }
    }
}
