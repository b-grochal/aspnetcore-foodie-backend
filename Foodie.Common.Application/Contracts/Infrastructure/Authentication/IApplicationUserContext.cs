using Foodie.Common.Enums;

namespace Foodie.Common.Application.Contracts.Infrastructure.Authentication
{
    public interface IApplicationUserContext
    {
        ApplicationUserRole Role { get; }

        int LocationId { get; }

        string Email { get; }

        int Id { get; }
    }
}
