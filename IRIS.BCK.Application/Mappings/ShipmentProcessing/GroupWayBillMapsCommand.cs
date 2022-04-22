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
        public static List<GroupWayBill> CreateGroupWayBillMapsCommand(CreateGroupWayBillCommand request)
        {
            var listOfGroupWaybillItems = new List<GroupWayBill>();

            foreach (var item in request.Waybills)
            {
                if (item.Waybill != "")
                {
                    var grp = new GroupWayBill
                    {
                        Id = request.Id,
                        GroupCode = request.GroupCode,
                        RId = new Guid(request.RId),
                        UserId = request.UserId,
                        ServiceCenterId = request.ServiceCenterId,
                        Waybill = item.Waybill
                    };
                    listOfGroupWaybillItems.Add(grp);
                }
            }

            return listOfGroupWaybillItems;
        }
    }
}