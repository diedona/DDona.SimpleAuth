namespace DDona.SimpleAuth.Api.Models.AppSettings
{
    public class JwtBearerConfiguration
    {
        public const string SectionName = "JwtBearerConfiguration";

        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string LifeTimeMinutes { get; set; } = string.Empty;

        public int LifeTimeMinutesInteger => string.IsNullOrEmpty(LifeTimeMinutes)
            ? 0
            : int.Parse(LifeTimeMinutes);
    }
}
