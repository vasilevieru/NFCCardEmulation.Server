using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFCCardEmulation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Persistence.Configuration
{
    class ShopConfiguration : EntityConfiguration<Shop>
    {
        public override void Configure(EntityTypeBuilder<Shop> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Category)
                .HasMaxLength(50);
        }
    }
}
