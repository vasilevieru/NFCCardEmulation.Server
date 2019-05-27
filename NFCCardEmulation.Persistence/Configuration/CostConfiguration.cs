using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFCCardEmulation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Persistence.Configuration
{
    class CostConfiguration : EntityConfiguration<Cost>
    {
        public override void Configure(EntityTypeBuilder<Cost> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Price)
                .IsRequired();
        }
    }
}
