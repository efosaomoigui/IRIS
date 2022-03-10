using IRIS.BCK.Core.Application.Business.GroupWayBillManifestMaps.Commands.CreateGroupWayBillManifestMap;
using IRIS.BCK.Core.Application.Business.GroupWayBillManifestMaps.Commands.UpdateGroupWayBillManifestMap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.ShipmentProcessing
{
    public class GroupWayBillManifestMapController : BaseApiController
    {
        [HttpPost("CreateGroupWayManifestMapBill", Name = "AddGroupWayBill")]
        public async Task<ActionResult<CreateGroupWayBillManifestMapCommandResponse>> Create([FromBody] CreateGroupWayBillManifestMapCommand createGroupWayBillManifestMapCommand)
        {
            var response = await _mediator.Send(createGroupWayBillManifestMapCommand);
            return Ok(response);
        }

        [HttpPut("GroupWayBillManifestMap/edit", Name = "UpdateGroupWayBillManifestMap")]
        public async Task<ActionResult<UpdateGroupWayBillManifestMapCommandResponse>> UpdateGroupWayBillManifestMap([FromBody] UpdateGroupWayBillManifestMapCommandResponse updateGroupWayBillManifestMapCommand)
        {
            var response = await _mediator.Send(updateGroupWayBillManifestMapCommand);
            return Ok(response);
        }
    }
}