using DDona.SimpleAuth.Domain.Repositories;
using DDona.SimpleAuth.Infra.Repositories;

namespace DDona.SimpleAuth.Api.Extensions
{
    public static class RepositoriesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
