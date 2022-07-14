using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateGroupWayBill;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.DeleteGroupWayBill;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateGroupWayBill;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetGroupWayBill;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetRoutes;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentByWayBillNumber;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.ShipmentProcessing
{
    public class GroupWayBillController : BaseApiController
    {
        [HttpGet("GroupWayBill/Getall", Name = "GetAllGroupWayBill")]
        public async Task<ActionResult<List<GroupWayBillListViewModel>>> GetAllGroupWayBill()
        {
            var group = await _mediator.Send(new GetGroupWayBillQuery());
            return Ok(group);
        }

        [HttpPost("CreateGroupWayBill", Name = "AddGroup")]
        public async Task<ActionResult<CreateGroupWayBillCommandResponse>> Create([FromBody] CreateGroupWayBillCommand createGroupWayBillCommand)
        {
            var response = await _mediator.Send(createGroupWayBillCommand);
            return Ok(response);
        }

        [HttpGet("GroupWayBill/RouteForGroupWaybill", Name = "GetRouteForGroupwaybill")]
        public async Task<ActionResult<List<RouteViewModel>>> GetRouteForGroupwaybill()
        {
            var routes = await _mediator.Send(new GetRouteForGroupWaybillQuery());
            return Ok(routes);
        }

        [HttpPut("GroupWayBill/edit", Name = "UpdateGroupWayBill")]
        public async Task<ActionResult<CreateGroupWayBillCommandResponse>> UpdateGroupWayBill([FromBody] UpdateGroupWayBillCommand updateGroupWayBillCommand)
        {
            var response = await _mediator.Send(updateGroupWayBillCommand);
            return Ok(response);
        }

        [HttpGet("GetGroupWaybillByRouteId/{routeid}")]
        public async Task<ActionResult<List<GroupWayBillListViewModel>>> GetGroupWaybillByRouteId([FromRoute] Guid routeid)
        {
            var shipment = new List<GroupWayBillListViewModel>();
            if (routeid.ToString() != null)
            {
                shipment = await _mediator.Send(new GetManifestGroupwaybillByRouteIdQuery(routeid.ToString()));
            }
            return Ok(shipment);
        }

        [HttpGet("GetGroupWaybillByGroupCode/{grpcode}")]
        public async Task<ActionResult<List<GroupWayBillListViewModel>>> GetGroupWaybillByGroupCode([FromRoute] string grpcode)
        {
            var shipment = await _mediator.Send(new GetManifestGroupwaybillByGroupQuery(grpcode)); 
            return Ok(shipment);
        }

        [HttpDelete("GroupWayBill/delete", Name = "DeleteGroupWayBill")]
        public async Task<ActionResult<DeleteGroupWayBillCommandResponse>> DeletedeleteGroupWayBill([FromBody] DeleteGroupWayBillCommand deleteGroupWayBillCommand)
        {
            var response = await _mediator.Send(deleteGroupWayBillCommand);
            return Ok(response);
        }

        [HttpGet("GroupWayBill/GroupWaybillNumber", Name = "GetGroupWaybillNumber")]
        public async Task<ActionResult<string>> GetGroupWaybillNumber()
        {
            var groupwaybillcode = await _mediator.Send(new GetNewGroupWayBillNumberQuery());
            return Ok(groupwaybillcode);
        }
    }
}