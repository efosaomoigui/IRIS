using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.ShipmentGroupWayBillMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.CreateShipmentGroupWayBillMap
{
    public class CreateShipmentGroupWayBillMapResponse : BaseResponse
    {
        public CreateShipmentGroupWayBillMapResponse() : base()
        {
        }

        public ShipmentGroupWayBillMapDto ShipmentGroupWayBillMapdto { get; set; }
    }
}