using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateManifest;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.DeleteManifest;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateManifest;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifest;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifestByGroupWayBill;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifestByManifestCode;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentByWayBillNumber;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.ShipmentProcessing
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ManifestController : BaseApiController
    {
        [HttpGet("Manifest/all", Name = "GetAllManifest")]
        public async Task<ActionResult<List<ManifestListViewModel>>> GetAllManifest()
        {
            var manifest = await _mediator.Send(new GetManifestQuery());
            return Ok(manifest);
        }

        [HttpGet("GetManifestByManifestCode/{manifestcode}")]
        public async Task<ActionResult<ManifestViewModel>> GetManifestByManifestCode([FromRoute] string manifestcode)
        {
            var manifest = new ManifestViewModel();

            if (manifestcode != null)
            {
                manifest = await _mediator.Send(new GetManifestByManifestCodeQuery(manifestcode.ToString()));
            }

            return Ok(manifest);
        }

        [HttpGet("GetManifestByGroupWayBillNumber/{groupwaybillid}")]
        public async Task<ActionResult<ManifestViewModel>> GetManifestByGroupWayBillNumber([FromRoute] Guid groupwaybillid)
        {
            var groupwaybill = new ManifestViewModel();

            if (groupwaybillid != null)
            {
                groupwaybill = await _mediator.Send(new GetManifestByGroupWayBillQuery(groupwaybillid.ToString()));
            }

            return Ok(groupwaybill);
        }

        [HttpPost("Manifest", Name = "AddManifest")]
        public async Task<ActionResult<CreateManifestCommandResponse>> Create([FromBody] CreateManifestCommand createManifestCommand)
        {
            var response = await _mediator.Send(createManifestCommand);
            return Ok(response);
        }

        [HttpPut("Manifest/edit", Name = "UpdateManifest")]
        public async Task<ActionResult<CreateManifestCommandResponse>> UpdateManifest([FromBody] UpdateManifestCommand updateManifestCommand)
        {
            var response = await _mediator.Send(updateManifestCommand);
            return Ok(response);
        }

        [HttpDelete("Manifest/delete", Name = "DeleteManifest")]
        public async Task<ActionResult<DeleteManifestCommandResponse>> DeleteManifest([FromBody] DeleteManifestCommand deleteManifestCommand)
        {
            var response = await _mediator.Send(deleteManifestCommand);
            return Ok(response);
        }

        [HttpGet("Manifest/ManifestNumber", Name = "GetManifestNumber")]
        public async Task<ActionResult<string>> GetManifestNumber() 
        {
            var groupwaybillcode = await _mediator.Send(new GetNewManifestNumberQuery());
            return Ok(groupwaybillcode);
        }
    }
}