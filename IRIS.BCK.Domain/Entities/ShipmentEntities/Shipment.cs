using GIGLS.Core.Enums;
using IRIS.BCK.Core.Domain.Entities.AddressEntities;
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
        public Guid ShipmentId { get; set; }
        public string Waybill { get; set; }

        //Customer Information
        public User Customer { get; set; }

        public Guid AddressId { get; set; }
        public Address CustomerAddress { get; set; }
        public decimal GrandTotal { get; set; }

        //Receivers Information
        public User Reciever { get; set; }

        // public Address AddressId { get; set; }
        public Address RecieverAddress { get; set; }

        //PickUp Options
        public PickupOptions PickupOptions { get; set; }

        //Shipment Items && pricing
        public virtual List<ShipmentItem> ShipmentItems { get; set; }
    }
}