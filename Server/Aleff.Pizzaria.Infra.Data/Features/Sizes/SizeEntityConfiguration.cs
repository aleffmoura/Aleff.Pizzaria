using Aleff.Pizzaria.Domain.Features.Sizes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Sizeria.Infra.Data.Features.Sizes
{
    public class SizeEntityConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Sizes");
            builder.Property(x => x.ESize).IsRequired();
            builder.Property(x => x.PreparationTime).IsRequired();
            builder.Property(x => x.Value).IsRequired();

        }
    }
}
