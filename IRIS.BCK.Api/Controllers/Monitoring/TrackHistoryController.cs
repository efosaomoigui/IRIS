using IRIS.BCK.Core.Application.Business.Monitoring.Commands.CreateTrackHistory;
using IRIS.BCK.Core.Application.Business.Monitoring.Commands.UpdateTrackHistory;
using IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistory;
using IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistoryById;
using IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistoryByTripId;
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
        [HttpGet("TrackHistory/all", Name = "GetTrackHistory")]
        public async Task<ActionResult<List<TrackHistoryListViewModel>>> GetAllTrackHistories()
        {
            var trackHistory = await _mediator.Send(new GetTrackHistoryQuery());
            return HandleQueryResult(trackHistory);
        }

        [HttpGet("GetTrackHistoryById/{trackhistoryid}")]
        public async Task<ActionResult<TrackHistoryViewModel>> GetTrackHistoryById([FromRoute] Guid trackhistoryid)
        {
            var trackHistory = new TrackHistoryViewModel();

            if (trackhistoryid != null)
            {
                trackHistory = await _mediator.Send(new GetTrackHistoryByIdQuery(trackhistoryid.ToString()));
            }

            return Ok(trackHistory);
        }

        [HttpGet("GetTrackHistoryByTripId/{tripid}")]
        public async Task<ActionResult<TrackHistoryViewModel>> GetTrackHistoryByTripId([FromRoute] Guid tripid)
        {
            var trip = new TrackHistoryViewModel();

            if (tripid != null)
            {
                trip = await _mediator.Send(new GetTrackHistoryByTripIdQuery(tripid.ToString()));
            }

            return Ok(trip);
        }

        [HttpGet("TrackHistory/GetTrackHistoryByManifestCode/{manifestcode}")]
        public async Task<ActionResult<List<TrackHistoryListViewModel>>> GetTrackHistoryByManifestCode(string manifestcode)
        {
            var code = await _mediator.Send(new GetTrackHistoryQuery());
            return Ok(code);
        }

        [HttpGet("TrackHistory/GetTrackHistoryByWayBill/{waybill}")]
        public async Task<ActionResult<List<TrackHistoryListViewModel>>> GetTrackHistoryByWayBill(string waybill)
        {
            var waybillnum = await _mediator.Send(new GetTrackHistoryQuery());
            return Ok(waybillnum);
        }

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