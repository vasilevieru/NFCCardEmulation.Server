using Microsoft.EntityFrameworkCore;
using NFCCardEmulation.Application.Interfaces;
using NFCCardEmulation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NFCCardEmulation.Persistence
{
    public class NFCCardEmulationDbContext : DbContext, INFCCardEmulationDbContext
    {
        public NFCCardEmulationDbContext(DbContextOptions<NFCCardEmulationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
               .Where(type => !string.IsNullOrEmpty(type.Namespace))
               .Where(type => type.BaseType != null &&
                              type.BaseType.IsGenericType &&
                              type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

        }
    }
}
