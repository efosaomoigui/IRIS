﻿using IRIS.BCK.Application.DTO;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateCollectionCenter;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteCollectionCenter;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteShipment;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateCollectionCenter;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateShipments;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetCollectionCenter;
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
        [HttpGet("Shipment/all", Name = "GetAllShipments")]
        public async Task<ActionResult<List<ShipmentListViewModel>>> GetAllShipments()
        {
            var shipments = await _mediator.Send(new GetShipmentListQuery());
            return Ok(shipments);
        }

        [HttpPost("Shipment", Name = "AddShipment")]
        public async Task<ActionResult<CreateShipmentCommandResponse>> Create([FromBody] CreateShipmentCommand createShipmentCommand)
        {
            var response = await _mediator.Send(createShipmentCommand);
            return Ok(response);
        }

        [HttpPut("Shipment", Name = "UpdateShipment")]
        public async Task<ActionResult<CreateShipmentCommandResponse>> UpdateShipment([FromBody] UpdateShipmentCommand updateShipmentCommand)
        {
            var response = await _mediator.Send(updateShipmentCommand);
            return Ok(response);
        }

        [HttpDelete("Shipment", Name = "DeleteShipment")]
        public async Task<ActionResult<CreateShipmentCommandResponse>> DeleteShipment([FromBody] DeleteShipmentCommand deleteShipmentCommand)
        {
            var response = await _mediator.Send(deleteShipmentCommand);
            return Ok(response);
        }

        #region CollectionCenter

        [HttpGet("CollectionCenter/all", Name = "GetAllCollectionCenter")]
        public async Task<ActionResult<List<CollectionCenterListViewModel>>> GetAllCollectionCenter()
        {
            var center = await _mediator.Send(new GetCollectionCenterQuery());
            return Ok(center);
        }

        [HttpPost("CollectionCenter", Name = "AddCollectionCenter")]
        public async Task<ActionResult<CreateCollectionCenterCommandResponse>> Create([FromBody] CreateCollectionCenterCommand createCollectionCenterCommand)
        {
            var response = await _mediator.Send(createCollectionCenterCommand);
            return Ok(response);
        }

        [HttpPut("CollectionCenter", Name = "UpdateCollectionCenter")]
        public async Task<ActionResult<UpdateCollectionCenterCommandResponse>> UpdateShipment([FromBody] UpdateCollectionCenterCommand updateCollectionCenterCommand)
        {
            var response = await _mediator.Send(updateCollectionCenterCommand);
            return Ok(response);
        }

        [HttpDelete("CollectionCenter", Name = "DeleteCollectionCenter")]
        public async Task<ActionResult<CreateCollectionCenterCommandResponse>> DeleteCollectionCenter([FromBody] DeleteCollectionCenterCommand deleteCollectionCenterCommand)
        {
            var response = await _mediator.Send(deleteCollectionCenterCommand);
            return Ok(response);
        }

        #endregion CollectionCenter
    }
}