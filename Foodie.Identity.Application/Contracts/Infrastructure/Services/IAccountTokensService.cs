namespace Foodie.Identity.Application.Contracts.Infrastructure.Services
{
    public interface IAccountTokensService
    {
        string GenerateAccountActivationToken();
    }
}
