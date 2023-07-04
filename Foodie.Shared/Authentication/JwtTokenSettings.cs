namespace Foodie.Shared.Authentication
{
    public class JwtTokenSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; } // TODO: Move property to separate configuration class for refresh token
    }
}
