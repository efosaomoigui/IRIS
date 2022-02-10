using IRIS.BCK.Application.DTO;
using IRIS.BCK.Core.Application.Business.Fleets.Queries;
using IRIS.BCK.Core.Application.Business.Fleets.Queries.GetFleets;
using IRIS.BCK.Core.Application.Business.Price.Commands.SpecialDomesticZonePrice;
using IRIS.BCK.Core.Application.Business.Price.Queries.GetSpecialDomesticZonePriceQuery;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateFleets;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateRoutes;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteFleet;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteRoute;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateFleet;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateRoute;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleets;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetRoutes;
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
        #region Route

        [HttpGet("Route/all", Name = "GetEntireRoutes")]
        public async Task<ActionResult<List<RouteViewModel>>> GetEntireRoutes()
        {
            var routes = await _mediator.Send(new GetRouteQuery());
            return Ok(routes);
        }

        [HttpPost("Route", Name = "AddShipmentRoute")]
        public async Task<ActionResult<CreateRouteCommandResponse>> AddShipmentRoute([FromBody] CreateRouteCommand createRouteCommand)
        {
            var response = await _mediator.Send(createRouteCommand);
            return Ok(response);
        }

        [HttpGet("Route/GetRouteById/{routeid}")]
        public async Task<ActionResult<List<ShipmentListViewModel>>> GetRouteById(string routeid)
        {
            var shipments = await _mediator.Send(new GetShipmentListQuery());
            return Ok(shipments);
        }

        [HttpPut("Route", Name = "EditRoute")]
        public async Task<ActionResult<CreateRouteCommandResponse>> UpdateRoute([FromBody] UpdateRouteCommand updateRouteCommand)
        {
            var response = await _mediator.Send(updateRouteCommand);
            return Ok(response);
        }

        [HttpDelete("Route", Name = "DeleteRoute")]
        public async Task<ActionResult<CreateRouteCommandResponse>> DeleteRoute([FromBody] DeleteRouteCommand deleteRouteCommand)
        {
            var response = await _mediator.Send(deleteRouteCommand);
            return Ok(response);
        }

        #endregion Route

        #region Fleet

        [HttpGet("Fleet/all", Name = "GetAllFleet")]
        public async Task<ActionResult<List<FleetListViewModel>>> GetAllFleet()
        {
            var fleet = await _mediator.Send(new GetFleetQuery());
            return Ok(fleet);
        }

        [HttpPost("Fleet", Name = "AddFleet")]
        public async Task<ActionResult<CreateFleetCommandResponse>> AddFleet([FromBody] CreateFleetCommand createFleetCommand)
        {
            var response = await _mediator.Send(createFleetCommand);
            return Ok(response);
        }

        [HttpPut("Fleet", Name = "EditFleet")]
        public async Task<ActionResult<CreateFleetCommandResponse>> UpdateFleet([FromBody] UpdateFleetCommand updateFleetCommand)
        {
            var response = await _mediator.Send(updateFleetCommand);
            return Ok(response);
        }

        [HttpDelete("Fleet", Name = "DeleteFleet")]
        public async Task<ActionResult<CreateFleetCommandResponse>> DeleteFleet([FromBody] DeleteFleetCommand deleteFleetCommand)
        {
            var response = await _mediator.Send(deleteFleetCommand);
            return Ok(response);
        }

        #endregion Fleet

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

        [HttpGet("all", Name = "GetAllSpecialDomesticZonePrice")]
        public async Task<ActionResult<List<SpecialDomesticZonePriceViewModel>>> GetAllSpecialDomesticZonePrice()
        {
            var shipments = await _mediator.Send(new GetSpecialDomesticZonePriceQuery());
            return Ok(shipments);
        }

        [HttpPost(Name = "AddSpecialDomesticZonePrice")]
        public async Task<ActionResult<CreateSpecialDomesticZonePriceCommandResponse>> Create([FromBody] CreateSpecialDomesticZonePriceCommand createSpecialDomesticZonePriceCommand)
        {
            var response = await _mediator.Send(createSpecialDomesticZonePriceCommand);
            return Ok(response);
        }

        [HttpGet("Price/GetPriceById/{priceid}")]
        public async Task<ActionResult<List<ShipmentListViewModel>>> GetPriceById(string routeid)
        {
            var shipments = await _mediator.Send(new GetShipmentListQuery());
            return Ok(shipments);
        }

        #endregion Price
    }
}