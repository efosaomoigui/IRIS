using GIGLS.Core.Enums;
using IRIS.BCK.Core.Domain.Entities.AddressEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.ShimentEntities
{
    public class Shipment : Auditable
    {
        [Key]
        public Guid ShipmentId { get; set; }

        public string Waybill { get; set; }

        //Customer Information
        public Guid Customer { get; set; }

        public decimal GrandTotal { get; set; }

        public virtual ICollection<Address> CustomerAddress { get; set; }

        //Receivers Information
        public Guid Reciever { get; set; }

        public virtual ICollection<Address> RecieverAddress { get; set; }

        //PickUp Options
        public PickupOptions PickupOptions { get; set; }

        //Shipment Items && pricing
        public virtual List<ShipmentItem> ShipmentItems { get; set; }

    }

}