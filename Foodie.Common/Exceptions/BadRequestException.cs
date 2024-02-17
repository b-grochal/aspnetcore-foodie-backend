namespace Foodie.Common.Exceptions
{
    public abstract class BadRequestException : AppException
    {
        protected BadRequestException(string message) : base(message) { }
    }
}
