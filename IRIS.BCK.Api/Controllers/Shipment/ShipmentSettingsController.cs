using IRIS.BCK.Application.DTO;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment;
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
    public class ShipmentSettingsController : BaseApiController
    {
        private readonly IMediator _mediator; 
        public ShipmentSettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Vehicle

        [HttpPost("Vehicle", Name = "AddVehicle")]
        public async Task<ActionResult<CreateShipmentCommandResponse>> CreateVehicle([FromBody] CreateShipmentCommand createShipmentCommand)
        {
            var response = await _mediator.Send(createShipmentCommand);
            return Ok(response); 
        }

        [HttpGet("Vehicle/all", Name = "GetAllVehicles")]
        public async Task<ActionResult<List<ShipmentListViewModel>>> GetAllVehicles()
        {
            var shipments = await _mediator.Send(new GetShipmentListQuery());
            return Ok(shipments);
        }

        [HttpGet("Vehicle/GetVehicleById/{vehicleid}")]
        public async Task<ActionResult<List<ShipmentListViewModel>>> GetVehicleById(string vehicleId)
        {
            var shipments = await _mediator.Send(new GetShipmentListQuery());
            return Ok(shipments);
        }

        [HttpGet("Vehicle/GetVehicleByMake/{make}")]
        public async Task<ActionResult<List<ShipmentListViewModel>>> GetVehicleByMake(string vehicleMake) 
        {
            var shipments = await _mediator.Send(new GetShipmentListQuery());
            return Ok(shipments);
        }

        [HttpGet("Vehicle/GetVehicleByUserOwner/{ownerId}")]
        public async Task<ActionResult<List<ShipmentListViewModel>>> GetVehicleByUserOwner(string ownerId) 
        {
            var shipments = await _mediator.Send(new GetShipmentListQuery());
            return Ok(shipments);
        }

        #endregion

        #region Route

        [HttpPost("Route", Name = "AddRoute")]
        public async Task<ActionResult<CreateShipmentCommandResponse>> AddRoute([FromBody] CreateShipmentCommand createShipmentCommand)
        {
            var response = await _mediator.Send(createShipmentCommand);
            return Ok(response);
        }

        [HttpGet("Route/all", Name = "GetAllRoutes")]
        public async Task<ActionResult<List<ShipmentListViewModel>>> GetAllRoutes()
        {
            var shipments = await _mediator.Send(new GetShipmentListQuery());
            return Ok(shipments);
        }

        [HttpGet("Route/GetRouteById/{routeid}")]
        public async Task<ActionResult<List<ShipmentListViewModel>>> GetRouteById(string routeid)
        {
            var shipments = await _mediator.Send(new GetShipmentListQuery());
            return Ok(shipments);
        }

        #endregion

        #region Price

        [HttpPost("Price", Name = "AddPrice")]
        public async Task<ActionResult<CreateShipmentCommandResponse>> AddPrice([FromBody] CreateShipmentCommand createShipmentCommand)
        {
            var response = await _mediator.Send(createShipmentCommand);
            return Ok(response);
        }

        [HttpGet("Price/all", Name = "GetAllPrice")]
        public async Task<ActionResult<List<ShipmentListViewModel>>> GetAllPrice() 
        {
            var shipments = await _mediator.Send(new GetShipmentListQuery());
            return Ok(shipments);
        }

        [HttpGet("Price/GetPriceById/{priceid}")]
        public async Task<ActionResult<List<ShipmentListViewModel>>> GetPriceById(string routeid) 
        {
            var shipments = await _mediator.Send(new GetShipmentListQuery());
            return Ok(shipments);
        }

        #endregion



    }
}
