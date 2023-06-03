namespace Foodie.Identity.Application.Contracts.Infrastructure.Services
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
