using DDona.SimpleAuth.Domain.Repositories;
using DDona.SimpleAuth.Domain.Services;
using DDona.SimpleAuth.Domain.Services.Interfaces;
using DDona.SimpleAuth.Domain.UnitOfWork;
using DDona.SimpleAuth.Infra.Repositories;
using DDona.SimpleAuth.Infra.UnitOfWork;

namespace DDona.SimpleAuth.Api.Extensions
{
    public static class DomainExtensions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
