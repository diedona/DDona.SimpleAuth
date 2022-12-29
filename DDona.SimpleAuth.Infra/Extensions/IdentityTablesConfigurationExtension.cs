using DDona.SimpleAuth.Application.Identity;
using DDona.SimpleAuth.Domain.Constants;
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

        public static void SeedIdentityTablesFirstAdminData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "903d67fb-019c-4f9c-9754-d9db3386aead", //TODO: read it from appsettings
                Name = UserRolesConstants.Administrator,
                NormalizedName = UserRolesConstants.Administrator.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "b0834507-4edb-40c9-9f91-71e20fcca003", //TODO: read it from appsettings
                Name = UserRolesConstants.Worker,
                NormalizedName = UserRolesConstants.Worker.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var user = new ApplicationUser()
            {
                Id = "8a521141-3f8e-4a1f-ae59-893445b475b8", //TODO: read it from appsettings
                UserName = "admin@system",
                FirstName = "System",
                LastName = "Owner",
                NormalizedUserName = "ADMIN@SYSTEM",
                Email = "admin@system",
                NormalizedEmail = "ADMIN@SYSTEM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            user.PasswordHash = passwordHasher.HashPassword(user, "Asd@123"); //TODO: read it from appsettings
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                RoleId = "903d67fb-019c-4f9c-9754-d9db3386aead",
                UserId = "8a521141-3f8e-4a1f-ae59-893445b475b8"
            });
        }
    }
}
