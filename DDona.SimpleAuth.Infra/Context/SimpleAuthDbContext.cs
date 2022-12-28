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
        }
    }
}
