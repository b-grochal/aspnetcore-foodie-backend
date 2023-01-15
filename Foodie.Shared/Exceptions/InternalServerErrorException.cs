using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Shared.Exceptions
{
    public abstract class InternalServerErrorException : Exception
    {
        protected InternalServerErrorException(string message) : base(message) { }
    }
}
