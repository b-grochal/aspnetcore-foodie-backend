using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Shared.Exceptions
{
    public class UnathorizedException : Exception
    {
        protected UnathorizedException(string message) : base(message) { }
    }
}
