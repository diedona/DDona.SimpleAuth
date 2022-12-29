﻿using DDona.SimpleAuth.Api.Extensions;

namespace DDona.SimpleAuth.Api
{
    public class Startup
    {
        public ConfigurationManager Configuration { get; }
        public ConfigureHostBuilder ConfigureHostBuilder { get; }

        public Startup(ConfigurationManager configuration, ConfigureHostBuilder configureHostBuilder)
        {
            Configuration = configuration;
            ConfigureHostBuilder = configureHostBuilder;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSerilog(Configuration, ConfigureHostBuilder);
            services.AddEntityFramework(Configuration);
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddRepositories();
            services.AddUnitOfWork();
            services.AddServices();
            services.AddControllersWithConfigurations();
            services.AddAspNetCoreIdentity();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void ConfigureJson()
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
            Configuration.AddJsonFile($"appsettings.{environment}.json", false, true);
        }

        public void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
