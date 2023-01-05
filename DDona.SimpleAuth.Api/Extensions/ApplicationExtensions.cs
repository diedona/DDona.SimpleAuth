using DDona.SimpleAuth.Application.Identity.Interfaces;
using DDona.SimpleAuth.Application.Services;
using DDona.SimpleAuth.Application.Services.Interfaces;
using DDona.SimpleAuth.Infra.Application.Identity.Managers;
using DDona.SimpleAuth.Infra.Application.Identity.Repositories;

namespace DDona.SimpleAuth.Api.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplicationManagers(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, ApplicationUserManager>();
            services.AddScoped<IRoleManager, ApplicationRoleManager>();
        }

        public static void AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
