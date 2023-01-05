namespace DDona.SimpleAuth.Application.Identity.Entities
{
    public class ApplicationUserRefreshToken
    {
        public ApplicationUser AspNetUser { get; private set; }
        public string AspNetUserId { get; private set; }
        public string Token { get; private set; }
        public DateTime ValidTo { get; private set; }

        private ApplicationUserRefreshToken() { } //EF

        public ApplicationUserRefreshToken(string aspNetUserId, string token, DateTime validTo)
        {
            AspNetUserId = aspNetUserId;
            Token = token;
            ValidTo = validTo;
        }

        public bool IsTokenValid() => ValidTo >= DateTime.UtcNow;
    }
}
