using DDona.SimpleAuth.Infra.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DDona.SimpleAuth.Infra.Extensions
{
    public static class IdentityTablesConfigurationExtension
    {
        public static void ApplyConfigurationForIdentityTables(this ModelBuilder modelBuilder)
        {
            string schema = "identity";

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers", schema);
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles", schema);
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaims", schema);
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles", schema);
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins", schema);
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaims", schema);
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens", schema);
        }
    }
}
