using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.ShipmentGroupWayBillMapEntities
{
    public class ShipmentGroupWayBillMap : Auditable
    {
        public Guid ShipmentGroupWayBillMapid { get; set; }
        public string ShipmentWaybill { get; set; }
        public string GroupWayBillCode { get; set; }
    }
}