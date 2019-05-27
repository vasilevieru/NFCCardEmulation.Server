using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFCCardEmulation.Domain.Entities;

namespace NFCCardEmulation.Persistence.Configuration
{
    class CardConfiguration : EntityConfiguration<Card>
    {
        public override void Configure(EntityTypeBuilder<Card> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Number)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(x => x.CVV)
                .HasMaxLength(3)
                .IsRequired();
        }
    }
}
