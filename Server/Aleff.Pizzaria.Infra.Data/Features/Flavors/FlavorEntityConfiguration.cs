using Aleff.Pizzaria.Domain.Features.Flavors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Infra.Data.Features.Flavors
{
    public class FlavorEntityConfiguration : IEntityTypeConfiguration<Flavor>
    {
        public void Configure(EntityTypeBuilder<Flavor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Flavors");
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PreparationTime).IsRequired();
        }
    }
}
