namespace DDona.SimpleAuth.Application.Identity.Entities
{
    public class ApplicationUserRefreshToken
    {
        public ApplicationUser AspNetUser { get; set; }
        public string AspNetUserId { get; set; }
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }

        private ApplicationUserRefreshToken() { } //EF

        public ApplicationUserRefreshToken(string aspNetUserId, string token, DateTime validTo)
        {
            AspNetUserId = aspNetUserId;
            Token = token;
            ValidTo = validTo;
        }
    }
}
