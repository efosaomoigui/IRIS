﻿using  IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Core.Domain.Entities.AddressEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById
{
    public class ShipmentViewModel
    {
        public Guid ShipmentId { get; set; }

        public string Waybill { get; set; }
        public string Invoice { get; set; } 
        public DateTime CreatedDate { get; set; }

        //Customer Information
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public Guid Customer { get; set; }

        public double GrandTotal { get; set; }
        public double Quantity { get; set; } 

        public string CustomerAddress { get; set; }

        //Receivers Information
        public string RecieverName { get; set; }
        public Guid Reciever { get; set; }
        public string RecieverPhoneNumber { get; set; }
        public string PaidStatus { get; set; }  

        public string RecieverAddress { get; set; }

        //PickUp Options
        public string PickupOptions { get; set; }
        public string ShipmentCategory { get; set; }

        //Shipment Items && pricing
        public List<ShipmentItemDto> ShipmentItems { get; set; }

        public Guid ServiceCenterId { get; set; }
    }
}