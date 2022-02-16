using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;

namespace IRIS.BCK.Core.Domain.Entities.ShipmentEntities
{
    public class CollectionCenter : Auditable
    {
        // public GUID Id { get; set; }
        public int ShipmentId { get; set; }

        public Shipment Shipment { get; set; }
        public bool CollectionStatus { get; set; }
        public User UserId { get; set; }
    }
}