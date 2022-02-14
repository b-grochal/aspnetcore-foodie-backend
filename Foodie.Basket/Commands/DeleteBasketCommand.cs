using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Commands
{
    public class DeleteBasketCommand : IRequest
    {
        public string UserId{ get; set; }

        public DeleteBasketCommand(int userId)
        {
            this.UserId = userId;
        }
    }
}
