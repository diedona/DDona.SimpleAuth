using DDona.SimpleAuth.Domain.UnitOfWork;
using DDona.SimpleAuth.Infra.UnitOfWork;

namespace DDona.SimpleAuth.Api.Extensions
{
    public static class UnitOfWorkExtensions
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
