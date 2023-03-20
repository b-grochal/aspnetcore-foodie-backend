using Foodie.Orders.Domain.AggregatesModel.BuyerAggregate;
using Foodie.Orders.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Configurations
{
    public class BuyerEntityTypeConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> buyerConfiguration)
        {
            buyerConfiguration.ToTable("Buyers");
            buyerConfiguration.HasKey(b => b.Id);
            buyerConfiguration.Ignore(b => b.DomainEvents);

            buyerConfiguration.Property(o => o.Id)
            .UseHiLo("BuyersSequence");

            buyerConfiguration.Property(b => b.CustomerId)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
