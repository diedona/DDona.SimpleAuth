using Serilog;
using Serilog.Events;
using System.Runtime.CompilerServices;

namespace DDona.SimpleAuth.Api.Extensions
{
    public static class SerilogExtensions
    {
        public static void AddSerilog(this IServiceCollection services, IConfiguration configuration, ConfigureHostBuilder host)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                //.WriteTo.Console(LogEventLevel.Information)
                .CreateLogger();

            host.UseSerilog(Log.Logger);
        }
    }
}
