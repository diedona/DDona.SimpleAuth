using DDona.SimpleAuth.Infra.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DDona.SimpleAuth.Infra.Context
{
    public class SimpleAuthDbContext : DbContext
    {
        public SimpleAuthDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>()
                .AreUnicode(false)
                .HaveMaxLength(1000);

            configurationBuilder.Properties<decimal>()
                .HavePrecision(9, 2); //6_500_000.00
        }
    }
}
