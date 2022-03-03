using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.ShipmentGroupWayBillMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.UpdateShipmentGroupWayBillMap
{
    public class UpdateShipmentGroupWayBillMapCommandResponse : BaseResponse
    {
        public UpdateShipmentGroupWayBillMapCommandResponse() : base()
        {
        }

        public ShipmentGroupWayBillMapDto ShipmentGroupWayBillMapdto { get; set; }
    }
}