namespace Foodie.Identity.Application.Features.Auth.Commands.RefreshJwtToken
{
    public class RefreshJwtTokenCommandResponse
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
