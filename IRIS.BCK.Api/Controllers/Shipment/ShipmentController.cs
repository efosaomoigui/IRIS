﻿using IRIS.BCK.Application.DTO;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateCollectionCenter;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteCollectionCenter;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteShipment;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateCollectionCenter;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateShipments;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetCollectionCenter;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentByWayBillNumber;
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
            return HandleQueryResult(shipments);
            //return Ok(shipments);
        }

        [HttpGet("GetShipmentById/{shipmentid}")]
        public async Task<ActionResult<ShipmentViewModel>> GetShipmentById([FromRoute] Guid shipmentid)
        {
            var shipment = new ShipmentViewModel();

            if (shipmentid != null)
            {
                shipment = await _mediator.Send(new GetShipmentByIdQuery(shipmentid.ToString()));
            }

            return Ok(shipment);
        }

        [HttpGet("GetShipmentByWayBillNumber/{waybillnumber}")]
        public async Task<ActionResult<ShipmentViewModel>> GetShipmentByWayBillNumber([FromRoute] string waybillnumber)
        {
            var waybill = new ShipmentViewModel();

            if (waybillnumber != null)
            {
                waybill = await _mediator.Send(new GetShipmentByWayBillNumberQuery(waybillnumber.ToString()));
            }

            return Ok(waybill);
        }

        [HttpPost("Shipment", Name = "AddShipment")]
        public async Task<ActionResult<CreateShipmentCommandResponse>> Create([FromBody] CreateShipmentCommand createShipmentCommand)
        {
            var response = await _mediator.Send(createShipmentCommand);
            return HandleCommandResult(response);
            //return Ok(response);
        }

        [HttpPut("Shipment/edit", Name = "UpdateShipment")]
        public async Task<ActionResult<UpdateShipmentCommandResponse>> UpdateShipment([FromBody] UpdateShipmentCommand updateShipmentCommand)
        {
            var response = await _mediator.Send(updateShipmentCommand);
            return Ok(response);
        }

        [HttpDelete("Shipment/delete", Name = "DeleteShipment")]
        public async Task<ActionResult<DeleteShipmentCommandResponse>> DeleteShipment([FromBody] DeleteShipmentCommand deleteShipmentCommand)
        {
            var response = await _mediator.Send(deleteShipmentCommand);
            return Ok(response);
        }
         
        [HttpGet("Shipment/WaybillAndInvoiceNumber", Name = "GetNewWaybillAndInvoiceNumber")]
        public async Task<ActionResult<List<NewWayBillViewModel>>> GetNewWaybillAndInvoiceNumber()
        {
            var center = await _mediator.Send(new GetNewWayBillNumberQuery());
            return Ok(center);
        }

        #region CollectionCenter

        [HttpGet("CollectionCenter/all", Name = "GetAllCollectionCenter")]
        public async Task<ActionResult<List<CollectionCenterListViewModel>>> GetAllCollectionCenter()
        {
            var center = await _mediator.Send(new GetCollectionCenterQuery());
            return Ok(center);
        }

        [HttpGet("ShipmentCollection/GetShipmentCollectionByWayBill/{waybill}")]
        public async Task<ActionResult<List<CollectionCenterListViewModel>>> GetTrackHistoryByTripId(string waybill)
        {
            var collection = await _mediator.Send(new GetCollectionCenterQuery());
            return Ok(collection);
        }

        [HttpPost("CollectionCenter", Name = "AddCollectionCenter")]
        public async Task<ActionResult<CreateCollectionCenterCommandResponse>> Create([FromBody] CreateCollectionCenterCommand createCollectionCenterCommand)
        {
            var response = await _mediator.Send(createCollectionCenterCommand);
            return Ok(response);
        }

        [HttpPut("CollectionCenter/edit", Name = "UpdateCollectionCenter")]
        public async Task<ActionResult<UpdateCollectionCenterCommandResponse>> UpdateCollectionCenter([FromBody] UpdateCollectionCenterCommand updateCollectionCenterCommand)
        {
            var response = await _mediator.Send(updateCollectionCenterCommand);
            return Ok(response);
        }

        [HttpDelete("CollectionCenter/delete", Name = "DeleteCollectionCenter")]
        public async Task<ActionResult<CreateCollectionCenterCommandResponse>> DeleteCollectionCenter([FromBody] DeleteCollectionCenterCommand deleteCollectionCenterCommand)
        {
            var response = await _mediator.Send(deleteCollectionCenterCommand);
            return Ok(response);
        }

        #endregion CollectionCenter
    }
}