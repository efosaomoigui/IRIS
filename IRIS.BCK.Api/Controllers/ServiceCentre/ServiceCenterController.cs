using IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.CreateServiceCenter;
using IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.DeleteServiceCenter;
using IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.UpdateServiceCenter;
using IRIS.BCK.Core.Application.Business.ServiceCentre.Queries.GetServiceCenter;
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
        [HttpGet("ServiceCenter/GetServiceCentertById/{servicecenterid}")]
        public async Task<ActionResult<List<ServiceCenterListViewModel>>> GetServiceCentertById(string servicecenterid)
        {
            var serviceCenter = await _mediator.Send(new GetServiceCenterQuery());
            return Ok(serviceCenter);
        }

        [HttpGet("ServiceCenter/all", Name = "GetAllServiceCenter")]
        public async Task<ActionResult<List<ServiceCenterListViewModel>>> GetAllServiceCenter()
        {
            var serviceCenter = await _mediator.Send(new GetServiceCenterQuery());
            return HandleQueryResult(serviceCenter);
        }

        [HttpPost("ServiceCenter", Name = "AddServiceCenter")]
        public async Task<ActionResult<CreateServiceCenterCommandResponse>> Create([FromBody] CreateServiceCenterCommand createServiceCenterCommand)
        {
            var response = await _mediator.Send(createServiceCenterCommand);
            return HandleCommandResult(response);
        }

        [HttpPut("ServiceCenter/edit", Name = "UpdateServiceCenter")]
        public async Task<ActionResult<UpdateServiceCenterCommandResponse>> UpdateServiceCenter([FromBody] UpdateServiceCenterCommand updateServiceCenterCommand)
        {
            var response = await _mediator.Send(updateServiceCenterCommand);
            return Ok(response);
        }

        [HttpDelete("ServiceCenter/delete", Name = "DeleteServiceCenter")]
        public async Task<ActionResult<DeleteServiceCenterCommandResponse>> DeleteServiceCenter([FromBody] DeleteServiceCenterCommand deleteServiceCenterCommand)
        {
            var response = await _mediator.Send(deleteServiceCenterCommand);
            return Ok(response);
        }
    }
}