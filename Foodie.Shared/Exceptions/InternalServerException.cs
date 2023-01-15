using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Shared.Exceptions
{
    public abstract class InternalServerException : Exception
    {
        protected InternalServerException(string message) : base(message) { }
    }
}
