using Foodie.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Domain.Exceptions
{
    public class AdminNotFoundException : NotFoundException
    {
        public AdminNotFoundException(string adminId) : base($"The admin with the indetifier {adminId} was not found.") { }
    }
}
