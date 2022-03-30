using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using IRIS.BCK.Core.Domain.Entities.GroupWayBillManifestMapEntities;
using IRIS.BCK.Core.Domain.Entities.Monitoring;
using IRIS.BCK.Core.Domain.Entities.NumberEnt;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.Entities.ServiceCenterEntities;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.Entities.ShipmentEntities;
using IRIS.BCK.Core.Domain.Entities.ShipmentGroupWayBillMapEntities;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using IRIS.BCK.Core.Domain.Entities.ShipmentRequestEntities;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
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
        public DbSet<CollectionCenter> CollectionCenter { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Manifest> Manifest { get; set; }
        public DbSet<GroupWayBill> GroupWayBill { get; set; }
        public DbSet<Trips> Trips { get; set; }
        public DbSet<PriceEnt> PriceEnt { get; set; }
        public DbSet<TrackHistory> TrackHistory { get; set; }
        public DbSet<ShipmentGroupWayBillMap> ShipmentGroupWayBillMap { get; set; }
        public DbSet<GroupWayBillManifestMap> GroupWayBillManifestMap { get; set; }
        public DbSet<ServiceCenter> ServiceCenter { get; set; }
        public DbSet<NumberEnt> NumberEnt { get; set; }
        public DbSet<PaymentLog> PaymentLog { get; set; }
        public DbSet<ShipmentRequest> ShipmentRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IRISDbContext).Assembly);
            modelBuilder.Entity<PriceEnt>().Property(p => p.PricePerUnit).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<PriceEnt>().Property(p => p.UnitWeight).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Shipment>().Property(p => p.GrandTotal).HasColumnType("decimal(18,4)");
            //modelBuilder.Entity<ShipmentItem>().Property(p => p.DeclarationOfValueCheck).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<WalletNumber>().Property(p => p.WalletBalance).HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Shipment>().HasMany(t => t.CustomerAddress)
                .WithOne(g => g.customershipmentAddress)
                .HasForeignKey(g => g.customershipmentAddressId);

            modelBuilder.Entity<Shipment>().HasMany(t => t.RecieverAddress)
                .WithOne(g => g.recievershipmentAddress)
                .HasForeignKey(g => g.recievershipmentAddressId);

            //many to many relationship
            modelBuilder.Entity<Route>()
                .HasMany(left => left.Price)
                .WithMany(right => right.Routes)
                .UsingEntity(join => join.ToTable("RoutePriceTbl"));
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