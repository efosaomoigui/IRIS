using IRIS.BCK.Core.Application.Business.Routes.Commands.CreateRoutes;
using IRIS.BCK.Core.Application.Business.Routes.Queries.GetRoutes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.Route
{
    public class RouteController : BaseApiController
    {
        [HttpGet("all", Name = "GetAllRoutes")]
        public async Task<ActionResult<List<RouteViewModel>>> GetAllRoutes()
        {
            var routes = await _mediator.Send(new GetRouteQuery());
            return Ok(routes);
        }

        [HttpPost(Name = "AddRoute")]
        public async Task<ActionResult<CreateRouteCommandResponse>> Create([FromBody] CreateRouteCommand createRouteCommand)
        {
            var response = await _mediator.Send(createRouteCommand);
            return Ok(response);
        }
    }
}