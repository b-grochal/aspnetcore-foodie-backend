using Foodie.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Domain.Exceptions
{
    public class OrderHandlerNotFoundException : NotFoundException
    {
        public OrderHandlerNotFoundException(string orderHandlerId) : base($"The order handler with the indetifier {orderHandlerId} was not found.") { }
    }
}
