using Aleff.Pizzaria.Domain.Features.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Infra.Data.Features.Orders
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.PreparationTime).IsRequired();
            builder.HasOne(x => x.Pizza)
                .WithMany()
                .HasForeignKey(x => x.PizzaId)
                .HasConstraintName("PizzaId");
        }
    }
}
