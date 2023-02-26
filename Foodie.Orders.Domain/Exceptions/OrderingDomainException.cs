using Foodie.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Domain.Exceptions
{
    public class OrderingDomainException : BadRequestException
    {
        protected OrderingDomainException(string message) : base(message) { }
    }
}
