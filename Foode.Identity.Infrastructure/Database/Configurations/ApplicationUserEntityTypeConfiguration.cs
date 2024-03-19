using Foodie.Identity.Domain.Common.ApplicationUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foode.Identity.Infrastructure.Database.Configurations
{
    internal class ApplicationUserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUsers");

            builder.HasKey(b => b.Id);

            builder.Property(o => o.FirstName);

            builder.Property(o => o.LastName);

            builder.Property(o => o.Email);

            builder.Property(o => o.PhoneNumber);

            builder.Property(o => o.PasswordHash);

            builder.Property(o => o.AccessFailedCount);

            builder.Property(o => o.IsLocked);

            builder.Property(o => o.IsActive);

            builder
                .Property(o => o.Role)
                .HasConversion<string>();

            builder.Property(o => o.IsActive);

            builder.OwnsOne(o => o.RefreshToken);
        }
    }
}
