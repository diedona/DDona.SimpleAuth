namespace DDona.SimpleAuth.Application.Models.AppSettings
{
    public class JwtBearerConfiguration
    {
        public const string SectionName = "JwtBearerConfiguration";

        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string AccessTokenLifeTimeMinutes { get; set; } = string.Empty;
        public string RefreshTokenLifeTimeMinutes { get; set; } = string.Empty;

        public int AccessTokenLifeTimeMinutesInteger =>
            string.IsNullOrEmpty(AccessTokenLifeTimeMinutes) ? 0 : int.Parse(AccessTokenLifeTimeMinutes);

        public int RefreshTokenLifeTimeMinutesInteger =>
            string.IsNullOrEmpty(RefreshTokenLifeTimeMinutes) ? 0 : int.Parse(RefreshTokenLifeTimeMinutes);
    }
}
