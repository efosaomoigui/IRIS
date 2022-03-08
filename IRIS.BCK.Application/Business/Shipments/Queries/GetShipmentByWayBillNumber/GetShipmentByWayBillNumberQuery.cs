using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentByWayBillNumber
{
    public class GetShipmentByWayBillNumberQuery : IRequest<ShipmentViewModel>
    {
        public string WayBill { get; set; }

        public GetShipmentByWayBillNumberQuery(string waybillnumber)
        {
            string ShipmentStr = new string(waybillnumber);
            WayBill = ShipmentStr;
        }
    }
}