using Foodie.Orders.Domain.Buyers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodie.Orders.Infrastructure.Database.Configurations
{
    public class BuyerEntityTypeConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> buyerConfiguration)
        {
            buyerConfiguration.ToTable("Buyers");

            buyerConfiguration.HasKey(b => b.Id);

            buyerConfiguration.Property(o => o.Id)
            .UseHiLo("BuyersSequence");

            buyerConfiguration.Property(b => b.CustomerId)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
