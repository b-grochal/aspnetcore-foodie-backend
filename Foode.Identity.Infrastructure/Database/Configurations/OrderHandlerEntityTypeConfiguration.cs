using Foodie.Identity.Domain.OrderHandlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foode.Identity.Infrastructure.Database.Configurations
{
    internal class OrderHandlerEntityTypeConfiguration : IEntityTypeConfiguration<OrderHandler>
    {
        public void Configure(EntityTypeBuilder<OrderHandler> builder)
        {
            builder.ToTable("OrderHandlers");

            builder.Property(o => o.LocationId);
        }
    }
}
