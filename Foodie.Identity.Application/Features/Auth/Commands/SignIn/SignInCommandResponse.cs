namespace Foodie.Identity.Application.Features.Auth.Commands.SignIn
{
    public class SignInCommandResponse
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
