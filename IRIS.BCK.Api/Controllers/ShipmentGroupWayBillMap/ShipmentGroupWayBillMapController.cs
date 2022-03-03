using IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.CreateShipmentGroupWayBillMap;
using IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.UpdateShipmentGroupWayBillMap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.ShipmentGroupWayBillMap
{
    public class ShipmentGroupWayBillMapController : BaseApiController
    {
        [HttpPost("CreateShipmentGroupWayBillMap", Name = "AddShipmentGroup")]
        public async Task<ActionResult<CreateShipmentGroupWayBillMapResponse>> Create([FromBody] CreateShipmentGroupWayBillMapCommand createShipmentGroupWayBillMapCommand)
        {
            var response = await _mediator.Send(createShipmentGroupWayBillMapCommand);
            return Ok(response);
        }

        [HttpPut("ShipmentGroupWayBillMap/edit", Name = "UpdateShipmentGroupWayBillMap")]
        public async Task<ActionResult<UpdateShipmentGroupWayBillMapCommandResponse>> UpdateGroupWayBill([FromBody] UpdateShipmentGroupWayBillMapCommand updateShipmentGroupWayBillMapCommand)
        {
            var response = await _mediator.Send(updateShipmentGroupWayBillMapCommand);
            return Ok(response);
        }
    }
}