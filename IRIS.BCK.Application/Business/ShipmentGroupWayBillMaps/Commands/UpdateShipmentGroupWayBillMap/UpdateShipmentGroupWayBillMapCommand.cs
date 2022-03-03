using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.UpdateShipmentGroupWayBillMap
{
    public class UpdateShipmentGroupWayBillMapCommand : IRequest<UpdateShipmentGroupWayBillMapCommandResponse>
    {
        public Guid ShipmentWayBillid { get; set; }
        public string ShipmentWaybill { get; set; }
        public string GroupWayBillCode { get; set; }
    }
}