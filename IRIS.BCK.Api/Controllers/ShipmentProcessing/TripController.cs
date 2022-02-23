using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateTrips;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.DeleteTrips;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateTrips;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetTrips;
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
    }
}