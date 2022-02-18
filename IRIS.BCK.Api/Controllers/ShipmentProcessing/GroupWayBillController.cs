using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateGroupWayBill;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateGroupWayBill;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.ShipmentProcessing
{
    public class GroupWayBillController : BaseApiController
    {
        [HttpPost("Bill/all", Name = "AddGroup")]
        public async Task<ActionResult<CreateGroupWayBillCommandResponse>> Create([FromBody] CreateGroupWayBillCommand createGroupWayBillCommand)
        {
            var response = await _mediator.Send(createGroupWayBillCommand);
            return Ok(response);
        }

        [HttpPut("GroupWayBill/edit", Name = "UpdateGroupWayBill")]
        public async Task<ActionResult<CreateGroupWayBillCommandResponse>> UpdateGroupWayBill([FromBody] UpdateGroupWayBillCommand updateGroupWayBillCommand)
        {
            var response = await _mediator.Send(updateGroupWayBillCommand);
            return Ok(response);
        }
    }
}