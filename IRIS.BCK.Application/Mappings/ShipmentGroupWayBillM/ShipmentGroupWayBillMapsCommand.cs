using IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.CreateShipmentGroupWayBillMap;
using IRIS.BCK.Core.Domain.Entities.ShipmentGroupWayBillMapEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.ShipmentGroupWayBillM
{
    public static class ShipmentGroupWayBillMapsCommand
    {
        public static ShipmentGroupWayBillMap CreateShipmentGroupWayBillMapsCommand(CreateShipmentGroupWayBillMapCommand request)
        {
            return new ShipmentGroupWayBillMap
            {
                ShipmentGroupWayBillMapid = request.ShipmentGroupWayBillMapid,
                ShipmentWaybill = request.ShipmentWaybill,
                GroupWayBillCode = request.GroupWayBillCode
            };
        }
    }
}