namespace DDona.SimpleAuth.Application.Identity
{
    public class ApplicationUserRefreshToken
    {
        public ApplicationUser AspNetUser { get; set; } = new();
        public string AspNetUserId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime ValidTo { get; set; }

        private ApplicationUserRefreshToken() { }
    }
}
