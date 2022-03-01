using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.AddressEntities
{
    public class Address : Auditable
    {
        [Key]
        public Guid AddressId { get; set; }

        public Guid User { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Guid ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
    }
}