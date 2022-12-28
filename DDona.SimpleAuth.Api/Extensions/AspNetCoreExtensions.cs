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
    }
}
