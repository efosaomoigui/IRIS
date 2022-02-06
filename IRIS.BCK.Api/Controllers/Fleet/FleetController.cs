using IRIS.BCK.Core.Application.Business.Fleets.Queries;
using IRIS.BCK.Core.Application.Business.Fleets.Queries.GetFleets;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateFleets;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleets;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.Fleet
{
    public class FleetController : BaseApiController
    {
        [HttpGet("all", Name = "GetAllFleet")]
        public async Task<ActionResult<List<FleetListViewModel>>> GetAllFleet()
        {
            var fleet = await _mediator.Send(new GetFleetQuery());
            return Ok(fleet);
        }

        [HttpPost(Name = "AddFleet")]
        public async Task<ActionResult<CreateFleetCommandResponse>> Create([FromBody] CreateFleetCommand createFleetCommand)
        {
            var response = await _mediator.Send(createFleetCommand);
            return Ok(response);
        }
    }
}