using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.ShipmentProcessing
{
    public class GroupWayBill : Auditable
    {
        public Guid Id { get; set; }
        public string GroupCode { get; set; }
        public Guid ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        public User UserId { get; set; }
    }
}