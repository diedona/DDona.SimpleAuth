using DDona.SimpleAuth.Domain.Services;
using DDona.SimpleAuth.Domain.Services.Interfaces;

namespace DDona.SimpleAuth.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
