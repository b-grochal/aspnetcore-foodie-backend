﻿using Foodie.Orders.Domain.AggregatesModel.ContractorAggregate;
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
    public class ContractorEntityTypeConfiguration : IEntityTypeConfiguration<Contractor>
    {
        public void Configure(EntityTypeBuilder<Contractor> contractorConfiguration)
        {
            contractorConfiguration.ToTable("Contractors");
            contractorConfiguration.HasKey(c => c.Id);
            contractorConfiguration.Ignore(c => c.DomainEvents);

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
