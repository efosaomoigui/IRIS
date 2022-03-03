using IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.CreateShipmentGroupWayBillMap;
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
    }
}