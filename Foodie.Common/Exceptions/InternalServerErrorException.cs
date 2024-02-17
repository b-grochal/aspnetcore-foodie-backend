namespace Foodie.Common.Exceptions
{
    public abstract class InternalServerErrorException : AppException
    {
        protected InternalServerErrorException(string message) : base(message) { }
    }
}
