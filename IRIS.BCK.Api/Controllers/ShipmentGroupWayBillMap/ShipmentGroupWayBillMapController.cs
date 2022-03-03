using IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.CreateShipmentGroupWayBillMap;
using IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.DeleteShipmentGroupWayBillMap;
using IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.UpdateShipmentGroupWayBillMap;
using IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Queries.GetShipmentGroupWayBillMap;
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
        [HttpGet("ShipmentGroupWayBill/Getall", Name = "GetAllShipmentGroupWayBill")]
        public async Task<ActionResult<List<ShipmentGroupWayBillMapListViewModel>>> GetAllGroupWayBill()
        {
            var shipmentGroup = await _mediator.Send(new GetShipmentGroupWayBillMapQuery());
            return Ok(shipmentGroup);
        }

        [HttpGet("ShipmentGroupWayBill/GetShipmentGroupWayBillMapById/{shipmentgroupwaybillid}")]
        public async Task<ActionResult<List<ShipmentGroupWayBillMapListViewModel>>> GetShipmentGroupWayBillMapById(string shipmentgroupwaybillid)
        {
            var shipmentId = await _mediator.Send(new GetShipmentGroupWayBillMapQuery());
            return Ok(shipmentId);
        }

        [HttpPost("CreateShipmentGroupWayBillMap", Name = "AddShipmentGroup")]
        public async Task<ActionResult<CreateShipmentGroupWayBillMapResponse>> Create([FromBody] CreateShipmentGroupWayBillMapCommand createShipmentGroupWayBillMapCommand)
        {
            var response = await _mediator.Send(createShipmentGroupWayBillMapCommand);
            return Ok(response);
        }

        [HttpPut("ShipmentGroupWayBillMap/edit", Name = "UpdateShipmentGroupWayBillMap")]
        public async Task<ActionResult<UpdateShipmentGroupWayBillMapCommandResponse>> UpdateShipmentGroupWayBill([FromBody] UpdateShipmentGroupWayBillMapCommand updateShipmentGroupWayBillMapCommand)
        {
            var response = await _mediator.Send(updateShipmentGroupWayBillMapCommand);
            return Ok(response);
        }

        [HttpDelete("ShipmentGroupWayBill/delete", Name = "DeleteShipmentGroupWayBill")]
        public async Task<ActionResult<DeleteShipmentGroupWayBillMapCommandResponse>> DeleteShipmentGroupWayBill([FromBody] DeleteShipmentGroupWayBillMapCommand deleteShipmentGroupWayBillMapCommand)
        {
            var response = await _mediator.Send(deleteShipmentGroupWayBillMapCommand);
            return Ok(response);
        }
    }
}