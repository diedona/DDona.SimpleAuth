using DDona.SimpleAuth.Application.Identity.Interfaces;
using DDona.SimpleAuth.Application.Services;
using DDona.SimpleAuth.Application.Services.Interfaces;
using DDona.SimpleAuth.Infra.Identity;

namespace DDona.SimpleAuth.Api.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplicationUserManager(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, ApplicationUserManager>();
            services.AddScoped<IRoleManager, ApplicationRoleManager>();
            services.AddScoped<IRefreshTokenManager, ApplicationRefreshTokenManager>();
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
