using DDona.SimpleAuth.Api.Extensions;

namespace DDona.SimpleAuth.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public ConfigureHostBuilder ConfigureHostBuilder { get; }

        public Startup(IConfiguration configuration, ConfigureHostBuilder configureHostBuilder)
        {
            Configuration = configuration;
            ConfigureHostBuilder = configureHostBuilder;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSerilog(ConfigureHostBuilder);
            services.AddEntityFramework(Configuration);
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddRepositories();
            services.AddUnitOfWork();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
