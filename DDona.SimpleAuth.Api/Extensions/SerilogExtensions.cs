using Serilog;

namespace DDona.SimpleAuth.Api.Extensions
{
    public static class SerilogExtensions
    {
        public static void AddSerilog(this IServiceCollection services, IConfiguration configuration, ConfigureHostBuilder host)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            host.UseSerilog(Log.Logger);
        }
    }
}
