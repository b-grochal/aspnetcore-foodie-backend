using Foodie.Identity.Domain.Admins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foode.Identity.Infrastructure.Database.Configurations
{
    internal class AdminEntityTypeConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");

            builder.HasQueryFilter(o => !o.IsDeleted);
        }
    }
}
