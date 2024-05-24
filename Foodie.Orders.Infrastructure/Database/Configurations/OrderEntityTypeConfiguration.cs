using Foodie.Orders.Domain.Buyers;
using Foodie.Orders.Domain.Contractors;
using Foodie.Orders.Domain.Orders;
using Foodie.Orders.Domain.Orders.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodie.Orders.Infrastructure.Database.Configurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            ConfigureOrdersTable(builder);
            ConfigureOrderItemsTable(builder);
        }

        private void ConfigureOrdersTable(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .UseHiLo("OrdersSequence");

            builder.Property(o => o.BuyerId);

            builder.Property(o => o.ContractorId);

            builder.Property(o => o.OrderStatus)
                .HasConversion(x => x.Name, x => OrderStatus.FromName(x))
                .IsRequired();

            builder.OwnsOne(o => o.DeliveryAddress, deliveryAddressBuilder =>
            {
                deliveryAddressBuilder
                .Property("OrderId")
                .UseHiLo("OrdersSequence");

                deliveryAddressBuilder.Property(d => d.Street);

                deliveryAddressBuilder.Property(d => d.City);

                deliveryAddressBuilder.Property(d => d.Country);
            });

            builder.HasOne<Buyer>()
            .WithMany()
            .IsRequired(false)
            .HasForeignKey(o => o.BuyerId);

            builder.HasOne<Contractor>()
            .WithMany()
            .IsRequired(false)
            .HasForeignKey(o => o.ContractorId);
        }

        private void ConfigureOrderItemsTable(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsMany(o => o.OrderItems, orderItemBuilder =>
            {
                orderItemBuilder.ToTable("OrderItems");

                orderItemBuilder.WithOwner()
                .HasForeignKey("OrderId");

                orderItemBuilder.HasKey(oi => oi.Id);

                orderItemBuilder.Property(oi => oi.Id)
                .UseHiLo("OrderItemsSequence");

                orderItemBuilder.Property(oi => oi.Name);

                orderItemBuilder.Property(oi => oi.UnitPrice);

                orderItemBuilder.Property(oi => oi.Quantity);

                orderItemBuilder.Property(oi => oi.MealId);
            });

            builder.Metadata
            .FindNavigation(nameof(Order.OrderItems))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
