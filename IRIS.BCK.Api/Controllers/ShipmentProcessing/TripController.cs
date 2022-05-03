﻿using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateTrips;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.DeleteTrips;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateTrips;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetTrips;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentByWayBillNumber;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.ShipmentProcessing
{
    public class TripController : BaseApiController
    {
        [HttpGet("Trip/all", Name = "GetTrips")]
        public async Task<ActionResult<List<TripListViewModel>>> GetAllTrips()
        {
            var trips = await _mediator.Send(new GetTripQuery());
            return HandleQueryResult(trips);
        }

        [HttpGet("Trip/ActionAndStatus", Name = "ActionAndStatus")]
        public async Task<ActionResult<TripActionAndStatusViewModel>> GetTripsAndStatus() 
        {
            var tripActionandStatus = await _mediator.Send(new GetTripActionAndStatusQuery());
            return HandleQueryResult(tripActionandStatus);
        }

        [HttpGet("Trip/GetTripByreferencCode/{referencCode}")]
        public async Task<ActionResult<List<TripListViewModel>>> GetTripByTripId(string referencCode)
        {
            var trip = await _mediator.Send(new GetTripByReferenceQuery(referencCode)); 
            return Ok(trip);
        }

        [HttpGet("Trip/GetTripByManifestCode/{manifestcode}")]
        public async Task<ActionResult<List<TripListViewModel>>> GetTripByManifestCode(string manifestcode)
        {
            var code = await _mediator.Send(new GetTripQuery());
            return Ok(code);
        }

        [HttpGet("Trip/GetTripByFleetNumber/{fleetnumber}")]
        public async Task<ActionResult<List<TripListViewModel>>> GetTripByFleetNumber(string fleetnumber)
        {
            var fleet = await _mediator.Send(new GetTripQuery());
            return Ok(fleet);
        }

        [HttpPost("Trip/Add", Name = "Add/Trip")]
        public async Task<ActionResult<CreateTripCommandResponse>> Create([FromBody] CreateTripCommand createTripCommand)
        {
            var response = await _mediator.Send(createTripCommand);
            return Ok(response);
        }

        [HttpPut("Trip/edit", Name = "UpdateTrip")]
        public async Task<ActionResult<UpdateTripCommandResponse>> UpdateTrip([FromBody] UpdateTripCommand updateTripCommand)
        {
            var response = await _mediator.Send(updateTripCommand);
            return Ok(response);
        }

        [HttpDelete("Trip/delete", Name = "DeleteTrip")]
        public async Task<ActionResult<DeleteTripCommandResponse>> DeleteTrip([FromBody] DeleteTripCommand deleteTripCommand)
        {
            var response = await _mediator.Send(deleteTripCommand);
            return Ok(response);
        }

        [HttpGet("Trip/TripReference", Name = "GetTripReference")]
        public async Task<ActionResult<string>> GetTripReference()
        {
            var groupwaybillcode = await _mediator.Send(new GetNewTripReferenceQuery());
            return Ok(groupwaybillcode);
        }

        [HttpGet("Trip/TripNumber", Name = "GetTripNumber")]
        public async Task<ActionResult<string>> GetTripNumber() 
        {
            var trpcode = await _mediator.Send(new GetNewTripReferenceQuery());
            return Ok(trpcode); 
        }
    }
}