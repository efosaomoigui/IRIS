using GIGLS.Core.Enums;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.ShimentEntities
{
    public class Shipment : Auditable
    {
        public int ShipmentId { get; set; }
        public string Waybill { get; set; }

        //Customer Information
        public User Customer { get; set; }

        public Address AddressId { get; set; }
        public Address CustomerAddress { get; set; }

        //Receivers Information
        public User Reciever { get; set; }

        // public Address AddressId { get; set; }
        public Address RecieverAddress { get; set; }

        //PickUp Options
        public PickupOptions PickupOptions { get; set; }

        //Shipment Items && pricing
        public virtual List<ShipmentItem> ShipmentItems { get; set; }

        public double length { get; set; }
        public double breadth { get; set; }
        public double Height { get; set; }
        public string DimensionUnit { get; set; } //cm / in

        public double ItemsWeight { get; set; }
        public bool IsWeightEstimated { get; set; }

        public bool IsdeclaredVal { get; set; }
        public decimal? DeclarationOfValueCheck { get; set; }
    }
}