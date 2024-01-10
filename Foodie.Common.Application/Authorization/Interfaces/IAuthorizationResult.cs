namespace Foodie.Common.Application.Authorization.Interfaces
{
    public interface IAuthorizationResult
    {
        bool IsAuthorized { get; }
    }
}
