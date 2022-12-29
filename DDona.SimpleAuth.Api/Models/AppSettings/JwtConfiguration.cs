namespace DDona.SimpleAuth.Api.Models.AppSettings
{
    public class JwtConfiguration
    {
        public string? Issuer { get; }
        public string? Audience { get; }
        public string? Key { get; }
        public string? LifeTimeMinutes { get; }

        public int LifeTimeMinutesInteger => string.IsNullOrEmpty(LifeTimeMinutes)
            ? 0
            : int.Parse(LifeTimeMinutes);
    }
}
