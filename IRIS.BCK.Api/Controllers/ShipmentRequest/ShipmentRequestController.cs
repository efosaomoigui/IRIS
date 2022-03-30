using IRIS.BCK.Core.Application.Business.ShipmentRequests.Commands.CreateShipmentRequest;
using IRIS.BCK.Core.Application.Business.ShipmentRequests.Commands.UpdateShipmentRequest;
using IRIS.BCK.Core.Application.Business.ShipmentRequests.Queries.GetShipmentRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.ShipmentRequest
{
    public class ShipmentRequestController : BaseApiController
    {
        [HttpGet("ShipmentRequest/all", Name = "GetAllShipmentRequest")]
        public async Task<ActionResult<List<ShipmentRequestListViewModel>>> GetAllShipmentRequest()
        {
            var shipmentRequest = await _mediator.Send(new GetShipmentRequestQuery());
            return HandleQueryResult(shipmentRequest);
        }

        [HttpPost("ShipmentRequest", Name = "AddShipmentRequest")]
        public async Task<ActionResult<CreateShipmentRequestCommandResponse>> Create([FromBody] CreateShipmentRequestCommand createShipmentRequestCommand)
        {
            var response = await _mediator.Send(createShipmentRequestCommand);
            return HandleCommandResult(response);
        }

        [HttpPut("ShipmentRequest/edit", Name = "UpdateShipmentRequest")]
        public async Task<ActionResult<UpdateShipmentRequestCommandResponse>> UpdateShipmentRequest([FromBody] UpdateShipmentRequestCommand updateShipmentRequestCommand)
        {
            var response = await _mediator.Send(updateShipmentRequestCommand);
            return Ok(response);
        }
    }
}