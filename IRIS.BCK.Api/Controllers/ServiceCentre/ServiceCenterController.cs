using IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.CreateServiceCenter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.ServiceCentre
{
    public class ServiceCenterController : BaseApiController
    {
        [HttpPost("ServiceCenter", Name = "AddServiceCenter")]
        public async Task<ActionResult<CreateServiceCenterCommandResponse>> Create([FromBody] CreateServiceCenterCommand createServiceCenterCommand)
        {
            var response = await _mediator.Send(createServiceCenterCommand);
            return HandleCommandResult(response);
        }
    }
}