namespace Foodie.Identity.Application.Contracts.Infrastructure.ApplicationUserUtilities
{
    public interface IAccountTokensService
    {
        string GenerateAccountActivationToken();
    }
}
