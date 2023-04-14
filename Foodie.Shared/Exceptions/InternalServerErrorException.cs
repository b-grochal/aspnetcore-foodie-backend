using System;

namespace Foodie.Shared.Exceptions
{
    public abstract class InternalServerErrorException : AppException
    {
        protected InternalServerErrorException(string message) : base(message) { }
    }
}
