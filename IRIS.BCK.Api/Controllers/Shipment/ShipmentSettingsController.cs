using IRIS.BCK.Application.DTO;
using IRIS.BCK.Core.Application.Business.Fleets.Queries;
using IRIS.BCK.Core.Application.Business.Fleets.Queries.GetFleets;
using IRIS.BCK.Core.Application.Business.Payments.Commands.CreateNumberEnt;
using IRIS.BCK.Core.Application.Business.Price.Commands.CreatePrice;
using IRIS.BCK.Core.Application.Business.Price.Commands.DeletePrice;
using IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem;
using IRIS.BCK.Core.Application.Business.Price.Commands.SpecialDomesticZonePrice;
using IRIS.BCK.Core.Application.Business.Price.Commands.UpdatePrice;
using IRIS.BCK.Core.Application.Business.Price.Queries.GetPrice;
using IRIS.BCK.Core.Application.Business.Price.Queries.GetPriceById;
using IRIS.BCK.Core.Application.Business.Price.Queries.GetPriceByRouteId;
using IRIS.BCK.Core.Application.Business.Price.Queries.GetSpecialDomesticZonePriceQuery;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateFleets;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateRoutes;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteFleet;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteRoute;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateFleet;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateRoute;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleetById;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleetByUserId;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleets;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetOneRoute;
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

        [HttpGet("GetRouteById/{routeid}")]
        public async Task<ActionResult<RouteViewModel>> GetRouteById([FromRoute] Guid routeid)
        {
            var route = new RouteViewModel();

            if (routeid != null)
            {
                route = await _mediator.Send(new GetRouteByIdQuery(routeid.ToString()));
            }

            return Ok(route);
        }

        [HttpPost("Route", Name = "AddShipmentRoute")]
        public async Task<ActionResult<CreateRouteCommandResponse>> AddShipmentRoute([FromBody] CreateRouteCommand createRouteCommand)
        {
            var response = await _mediator.Send(createRouteCommand);
            return Ok(response);
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

        [HttpGet("GetFleetById/{fleetid}")]
        public async Task<ActionResult<FleetViewModel>> GetFleetById([FromRoute] Guid fleetid)
        {
            var fleet = new FleetViewModel();

            if (fleetid != null)
            {
                fleet = await _mediator.Send(new GetFleetByIdQuery(fleetid.ToString()));
            }

            return Ok(fleet);
        }

        [HttpGet("GetFleetByUserId/{userid}")]
        public async Task<ActionResult<FleetViewModel>> GetFleetByUserId([FromRoute] Guid userid)
        {
            var user = new FleetViewModel();

            if (userid != null)
            {
                user = await _mediator.Send(new GetFleetByUserIdQuery(userid.ToString()));
            }

            return Ok(user);
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
        public async Task<ActionResult<CreatePriceCommandResponse>> AddPrice([FromBody] CreatePriceCommand createPriceCommand)
        {
            var response = await _mediator.Send(createPriceCommand);
            return Ok(response);
        }

        [HttpGet("Price/all", Name = "GetAllPrice")]
        public async Task<ActionResult<List<PriceListViewModel>>> GetAllPrice()
        {
            var price = await _mediator.Send(new GetPriceQuery());
            return Ok(price);
        }

        [HttpGet("GetPriceById/{priceid}")]
        public async Task<ActionResult<PriceViewModel>> GetPriceById([FromRoute] Guid priceid)
        {
            var price = new PriceViewModel();

            if (priceid != null)
            {
                price = await _mediator.Send(new GetPriceByIdQuery(priceid.ToString()));
            }

            return Ok(price);
        }

        [HttpPost("PriceSettings", Name = "PriceForShipmentItem")]
        public async Task<ActionResult<PriceForShipmentItemCommandResponse>> PriceForShipment([FromBody] PriceForShipmentItemCommand priceForShipmentItem)  
        {
            var response = await _mediator.Send(priceForShipmentItem);
            return Ok(response);
        }


        [HttpGet("GetPriceByRouteId/{routeid}")]
        public async Task<ActionResult<PriceViewModel>> GetPriceByRouteId([FromRoute] Guid routeid)
        {
            var route = new PriceViewModel();

            if (routeid != null)
            {
                route = await _mediator.Send(new GetPriceByRouteIdQuery(routeid.ToString()));
            }

            return Ok(route);
        }

        [HttpPut("Price", Name = "EditPrice")]
        public async Task<ActionResult<UpdatePriceCommandResponse>> UpdatePrice([FromBody] UpdatePriceCommand updatePriceCommand)
        {
            var response = await _mediator.Send(updatePriceCommand);
            return Ok(response);
        }

        [HttpDelete("Price", Name = "DeletePrice")]
        public async Task<ActionResult<CreatePriceCommandResponse>> DeletePrice([FromBody] DeletePriceCommand deletePriceCommand)
        {
            var response = await _mediator.Send(deletePriceCommand);
            return Ok(response);
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

        [HttpPost("all/GetNumber", Name = "GetNumber")]
        public async Task<ActionResult<string>> GetNumber([FromBody] CreateNumberCommand command)
        {
            var shipments = await _mediator.Send(command);
            return Ok(shipments);
        }

        #endregion Price
    }
}