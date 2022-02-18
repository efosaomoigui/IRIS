using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateGroupWayBill;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.ShipmentProcessing
{
    public static class GroupWayBillMapsCommand
    {
        public static GroupWayBill CreateGroupWayBillMapsCommand(CreateGroupWayBillCommand request)
        {
            return new GroupWayBill
            {
                Id = request.Id,
                Shipment = request.Shipment,
                GroupCode = request.GroupCode,
                ShipmentId = request.ShipmentId
            };
        }
    }
}