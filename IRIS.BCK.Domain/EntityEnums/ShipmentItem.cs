using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.EntityEnums
{
    public class ShipmentItem
    {
        public Guid ShipmentItemId { get; set; }

        public double length { get; set; }
        public double breadth { get; set; }
        public double Height { get; set; }
        public string DimensionUnit { get; set; } //cm / in

        public double ItemsWeight { get; set; }
        public bool IsVolumnWeight { get; set; } 
        public bool IsWeightEstimated { get; set; }

        public bool IsdeclaredVal { get; set; }
        public decimal DeclarationOfValueCheck { get; set; }

        public Guid ShipmentId { get; set; } 
        public Shipment Shipment { get; set; }

    }
}