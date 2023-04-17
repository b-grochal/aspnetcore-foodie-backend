namespace Foodie.Shared.Exceptions
{
    public abstract class BadRequestException : AppException
    {
        protected BadRequestException(string message) : base(message) { }
    }
}
