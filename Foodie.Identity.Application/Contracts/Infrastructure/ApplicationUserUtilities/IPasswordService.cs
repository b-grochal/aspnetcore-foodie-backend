namespace Foodie.Identity.Application.Contracts.Infrastructure.ApplicationUserUtilities
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
