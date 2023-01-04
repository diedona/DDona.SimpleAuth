
using DDona.SimpleAuth.Application.Identity;
using DDona.SimpleAuth.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DDona.SimpleAuth.Infra.Configurations.Application
{
    public class ApplicationUserRefreshTokenConfiguration : IEntityTypeConfiguration<ApplicationUserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRefreshToken> builder)
        {
            builder.ToTable("AspNetUserRefreshTokens", IdentityTablesConfigurationExtension.Schema);
            builder.HasKey(x => new { x.AspNetUserId, x.Token });
            builder.HasOne(x => x.AspNetUser)
                .WithMany(x => x.RefreshTokens);
        }
    }
}
