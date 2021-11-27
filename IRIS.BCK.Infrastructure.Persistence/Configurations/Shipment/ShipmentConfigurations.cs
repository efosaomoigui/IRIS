using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Configurations
{
    class ShipmentConfigurations : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired()
                .HasMaxLength(100); 
        }
    }
}
