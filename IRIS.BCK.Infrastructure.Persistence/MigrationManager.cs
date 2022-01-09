using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<IRISDbContext>())
                {
                    try
                    {
                        context.Database.Migrate(); // apply all migrations
                        //SeedData.Initialize(services); // Insert default data
                    }
                    catch (Exception ex)
                    {
                        //var logger = services.GetRequiredService<ILogger<Program>>();
                        //logger.LogError(ex, "An error occurred seeding the DB.");
                    }
                }
            }

            return host;
        }
    }
}
