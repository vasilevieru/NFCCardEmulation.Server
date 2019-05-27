using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFCCardEmulation.Domain.Entities;

namespace NFCCardEmulation.Persistence.Configuration
{
    class UserConfiguration : EntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(e => e.Email)
                .IsUnique();
        }
    }
}
