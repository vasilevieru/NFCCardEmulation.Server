using Microsoft.EntityFrameworkCore;
using NFCCardEmulation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NFCCardEmulation.Application.Interfaces
{
    public interface INFCCardEmulationDbContext
    {
        DbSet<Card> Cards { get; set; }
        DbSet<Cost> Costs { get; set; }
        DbSet<Shop> Shops { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
