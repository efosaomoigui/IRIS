using  IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Core.Domain.Entities.AddressEntities;
using IRIS.BCK.Core.Domain.Entities.ServiceCenterEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;

namespace IRIS.BCK.Core.Domain.Entities.ShimentEntities
{
    public class Shipment : Auditable
    {
        [Key]
        public Guid ShipmentId { get; set; }

        public string Waybill { get; set; }

        //Customer Information
        public string CustomerName { get; set; }
        public Guid Customer { get; set; }

        public double GrandTotal { get; set; }

        public string CustomerAddress { get; set; }
        //public ICollection<Address> CustomerAddress { get; set; }

        //Receivers Information
        public string RecieverName { get; set; } 
        public Guid Reciever { get; set; }

        public string RecieverAddress { get; set; }
        //public ICollection<Address> RecieverAddress { get; set; }

        //PickUp Options
        public PickupOptions PickupOptions { get; set; }
        public ShipmentCategory ShipmentCategory { get; set; } 
        public ShipmentOption ShipmentOption { get; set; }  
        public ShipmentProcessingStatus ShipmentProcessingStatus { get; set; }  

        //Shipment Items && pricing
        public List<ShipmentItem> ShipmentItems { get; set; }

        public Guid ShipmentRouteId { get; set; }   
        public Route Route { get; set; }         

        public Guid ServiceCenterId { get; set; }
    }
}