using DDona.SimpleAuth.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DDona.SimpleAuth.Api.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SimpleAuthDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });
        }
    }
}
