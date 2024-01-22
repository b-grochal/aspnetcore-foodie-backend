namespace Foodie.Common.Exceptions
{
    public abstract class NotFoundException : AppException
    {
        protected NotFoundException(string message) : base(message) { }
    }
}
