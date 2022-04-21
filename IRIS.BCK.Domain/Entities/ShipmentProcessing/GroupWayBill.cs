﻿using IRIS.BCK.Core.Domain.Entities.ServiceCenterEntities;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
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
        public Shipment Shipment { get; set; }
        public string Waybill { get; set; }
        public Guid RouteId { get; set; } 
        public Guid ServiceCenterId { get; set; }
    }
}