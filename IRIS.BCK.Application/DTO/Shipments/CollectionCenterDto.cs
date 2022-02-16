using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.DTO.Shipments
{
    public class CollectionCenterDto
    {
        public int ShipmentId { get; set; }

        public Shipment Shipment { get; set; }
        public bool CollectionStatus { get; set; }
        public User UserId { get; set; }
    }
}