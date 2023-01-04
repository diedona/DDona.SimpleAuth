namespace DDona.SimpleAuth.Application.Models.Jwt
{
    public record JwtOldTokenRequest
    {
        public string currentToken { get; set; }
        public string refreshToken { get; set; }
    }
}
