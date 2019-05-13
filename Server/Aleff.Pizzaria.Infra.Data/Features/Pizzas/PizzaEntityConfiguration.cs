using Aleff.Pizzaria.Domain.Features.Flavors;
using Aleff.Pizzaria.Domain.Features.Pizzas;
using Aleff.Pizzaria.Domain.Features.Sizes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Infra.Data.Features.Pizzas
{
    public class PizzaEntityConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Pizzas");

            builder.HasOne(x => x.Flavor)
                .WithMany(x => x.Pizzas)
                .HasForeignKey(x => x.Flavor)
                .HasConstraintName("FlavorId");

            builder.HasOne(x => x.Size)
                .WithMany(x => x.Pizzas)
                .HasForeignKey(x => x.Size)
                .HasConstraintName("SizeId");

            builder.Property(x => x.Customizations).HasMaxLength(50);
        }
    }
}
