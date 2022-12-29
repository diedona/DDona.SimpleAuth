using DDona.SimpleAuth.Application.Identity;
using DDona.SimpleAuth.Infra.Configurations;
using DDona.SimpleAuth.Infra.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DDona.SimpleAuth.Infra.Context
{
    public class SimpleAuthDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public SimpleAuthDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfigurationForIdentityTables();
            modelBuilder.SeedIdentityTablesFirstAdminData();
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
