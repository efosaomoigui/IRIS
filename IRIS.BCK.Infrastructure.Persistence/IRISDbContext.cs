using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using IRIS.BCK.Domain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence
{
    public class IRISDbContext : IdentityDbContext<User, AppRole, string, IdentityUserClaim<string>, IdentityUserRole<string>,
    IdentityUserLogin<string>, AppRoleClaim, IdentityUserToken<string>>
    {
        public IRISDbContext(DbContextOptions<IRISDbContext> options) : base(options)
        {
        }

        public DbSet<Shipment> Shipment { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<Fleet> Fleet { get; set; }
        public DbSet<WalletNumber> WalletNumber { get; set; }
        public DbSet<WalletTransaction> WalletTransaction { get; set; }

        public DbSet<AppRoleClaim> RoleClaim { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IRISDbContext).Assembly);
            modelBuilder.Entity<PriceEnt>().Property(p => p.PricePerUnit).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<PriceEnt>().Property(p => p.UnitWeight).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Route>().Property(p => p.CaptainFee).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Route>().Property(p => p.LoaderFee).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Shipment>().Property(p => p.DeclarationOfValueCheck).HasColumnType("decimal(18,4)");

            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //   .SelectMany(t => t.GetProperties())
            //   .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            //{

            //    property.Relational().ColumnType = "decimal(18,2)";


            //}
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Auditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}