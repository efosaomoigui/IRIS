using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence
{
    public class IRISDbContext : DbContext
    {
        public IRISDbContext(DbContextOptions<IRISDbContext> options) : base(options)
        {

        }

        public DbSet<Shipment> Shipment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        
    }
}
