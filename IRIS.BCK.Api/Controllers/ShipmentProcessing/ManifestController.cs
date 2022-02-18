using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateManifest;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.DeleteManifest;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateManifest;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifest;
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
    }
}