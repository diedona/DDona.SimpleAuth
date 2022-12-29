using DDona.SimpleAuth.Application.Identity;
using DDona.SimpleAuth.Infra.Context;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace DDona.SimpleAuth.Api.Extensions
{
    public static class AspNetCoreExtensions
    {
        public static void AddControllersWithConfigurations(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }

        public static void AddAspNetCoreIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            }).AddEntityFrameworkStores<SimpleAuthDbContext>();
        }
    }
}
