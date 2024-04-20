using Foodie.Orders.Domain.Contractors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodie.Orders.Infrastructure.Database.Configurations
{
    public class ContractorEntityTypeConfiguration : IEntityTypeConfiguration<Contractor>
    {
        public void Configure(EntityTypeBuilder<Contractor> contractorConfiguration)
        {
            contractorConfiguration.ToTable("Contractors");

            contractorConfiguration.HasKey(c => c.Id);

            contractorConfiguration.Property(o => o.Id)
            .UseHiLo("ContractorsSequence");

            contractorConfiguration.Property(c => c.RestaurantId)
                .IsRequired();

            contractorConfiguration.Property(c => c.CityId)
                .IsRequired();

            contractorConfiguration.Property(b => b.LocationId)
                .IsRequired();
        }
    }
}
