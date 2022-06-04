using Foodie.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Domain.Exceptions
{
    public class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException(string customerId) : base($"The customer with the indetifier {customerId} was not found.") { }
    }
}
