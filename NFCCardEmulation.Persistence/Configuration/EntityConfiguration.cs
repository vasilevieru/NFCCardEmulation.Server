using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFCCardEmulation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Persistence.Configuration
{
    abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
        }
    }
}
