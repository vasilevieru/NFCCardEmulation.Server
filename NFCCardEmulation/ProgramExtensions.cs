using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NFCCardEmulation.Application.Interfaces;
using NFCCardEmulation.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFCCardEmulation
{
    public static class ProgramExtensions
    {
        public static IWebHost MigrateDatabase(this IWebHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<INFCCardEmulationDbContext>();

                    var concreteContext = (NFCCardEmulationDbContext)context;
                    concreteContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }

            return webHost;
        }
    }
}
