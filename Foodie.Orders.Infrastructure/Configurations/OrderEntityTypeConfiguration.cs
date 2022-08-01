using Foodie.Orders.Domain.AggregatesModel.BuyerAggregate;
using Foodie.Orders.Domain.AggregatesModel.ContractorAggregate;
using Foodie.Orders.Domain.AggregatesModel.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Configurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> orderConfiguration)
        {
            orderConfiguration.ToTable("orders");
            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Ignore(o => o.DomainEvents);

            orderConfiguration
            .Property<int?>("_buyerId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("BuyerId")
            .IsRequired(false);

            orderConfiguration
            .Property<int?>("_contractorId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("BuyerId")
            .IsRequired(false);

            orderConfiguration
            .Property<DateTime>("_orderDate")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("OrderDate")
            .IsRequired();

            orderConfiguration
            .Property<int>("_orderStatusId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("OrderStatusId")
            .IsRequired();

            orderConfiguration.OwnsOne(o => o.Address);

            var navigation = orderConfiguration.Metadata.FindNavigation(nameof(Order.OrderItems));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            orderConfiguration
            .HasOne<Buyer>()
            .WithMany()
            .IsRequired(false)
            .HasForeignKey("_buyerId");

            orderConfiguration
            .HasOne<Contractor>()
            .WithMany()
            .IsRequired(false)
            .HasForeignKey("_contractorId");

            orderConfiguration
            .HasOne(o => o.OrderStatus)
            .WithMany()
            .HasForeignKey("_orderStatusId");
        }
    }
}
