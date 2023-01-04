namespace DDona.SimpleAuth.Application.Models.Jwt
{
    public record JwtTokenResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
    }
}
