using IRIS.BCK.Application.DTO;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteShipment;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateShipments;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.Shipment
{
    public class ShipmentController : BaseApiController
    {
        [HttpGet("all", Name = "GetAllShipments")]
        public async Task<ActionResult<List<ShipmentListViewModel>>> GetAllShipments()
        {
            var shipments = await _mediator.Send(new GetShipmentListQuery());
            return Ok(shipments);
        }

        [HttpPost(Name = "AddShipment")]
        public async Task<ActionResult<CreateShipmentCommandResponse>> Create([FromBody] CreateShipmentCommand createShipmentCommand)
        {
            var response = await _mediator.Send(createShipmentCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateShipment")]
        public async Task<ActionResult<CreateShipmentCommandResponse>> UpdateShipment([FromBody] UpdateShipmentCommand updateShipmentCommand)
        {
            var response = await _mediator.Send(updateShipmentCommand);
            return Ok(response);
        }

        [HttpDelete(Name = "DeleteShipment")]
        public async Task<ActionResult<CreateShipmentCommandResponse>> DeleteShipment([FromBody] DeleteShipmentCommand deleteShipmentCommand)
        {
            var response = await _mediator.Send(deleteShipmentCommand);
            return Ok(response);
        }
    }
}