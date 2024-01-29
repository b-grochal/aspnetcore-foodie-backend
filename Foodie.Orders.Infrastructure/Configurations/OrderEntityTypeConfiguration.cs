using Foodie.Orders.Domain.Buyers;
using Foodie.Orders.Domain.Contractors;
using Foodie.Orders.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Foodie.Orders.Infrastructure.Configurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> orderConfiguration)
        {
            orderConfiguration.ToTable("Orders");
            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Ignore(o => o.DomainEvents);

            orderConfiguration.Property(o => o.Id)
            .UseHiLo("OrdersSequence");

            orderConfiguration
            .Property<int?>("_buyerId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("BuyerId")
            .IsRequired(false);

            orderConfiguration
            .Property<int?>("_contractorId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("ContractorId")
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

            orderConfiguration
            .OwnsOne(o => o.Address, a =>
            {
                a.Property<int>("OrderId")
                .UseHiLo("OrdersSequence");
                a.WithOwner();
            });

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
