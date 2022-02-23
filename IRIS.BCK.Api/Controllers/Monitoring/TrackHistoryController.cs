using IRIS.BCK.Core.Application.Business.Monitoring.Commands.CreateTrackHistory;
using IRIS.BCK.Core.Application.Business.Monitoring.Commands.UpdateTrackHistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.Monitoring
{
    public class TrackHistoryController : BaseApiController
    {
        [HttpPost("TrackHistory", Name = "AddTrackHistory")]
        public async Task<ActionResult<CreateTrackHistoryCommandResponse>> Create([FromBody] CreateTrackHistoryCommand createTrackHistoryCommand)
        {
            var response = await _mediator.Send(createTrackHistoryCommand);
            return Ok(response);
        }

        [HttpPut("TrackHistory/edit", Name = "UpdateTrackHistory")]
        public async Task<ActionResult<UpdateTrackHistoryCommandResponse>> UpdateShipment([FromBody] UpdateTrackHistoryCommand updateTrackHistoryCommand)
        {
            var response = await _mediator.Send(updateTrackHistoryCommand);
            return Ok(response);
        }
    }
}