using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;

namespace IRIS.BCK.Core.Domain.Entities.ShipmentEntities
{
    public class CollectionCenter : Auditable
    {
        public Guid Id { get; set; }
        public Guid ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }
        public CollectionCenterEnum CollectionStatus { get; set; }
        public User UserId { get; set; }
    }
}