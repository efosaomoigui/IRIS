using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.CreateShipmentGroupWayBillMap
{
    public class CreateShipmentGroupWayBillMapCommand : IRequest<CreateShipmentGroupWayBillMapResponse>
    {
        public Guid ShipmentGroupWayBillMapid { get; set; }
        public string ShipmentWaybill { get; set; }
        public string GroupWayBillCode { get; set; }
    }
}