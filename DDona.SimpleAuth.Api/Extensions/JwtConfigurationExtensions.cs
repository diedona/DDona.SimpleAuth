using DDona.SimpleAuth.Application.Models.AppSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DDona.SimpleAuth.Api.Extensions
{
    public static class JwtConfigurationExtensions
    {
        public static void AddJwtConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            var jwtSection = configuration.GetSection(JwtBearerConfiguration.SectionName);
            services.Configure<JwtBearerConfiguration>(jwtSection);

            var jwtConfiguration = jwtSection.Get<JwtBearerConfiguration>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = jwtConfiguration.Issuer,
                    ValidAudience = jwtConfiguration.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
        }
    }
}
