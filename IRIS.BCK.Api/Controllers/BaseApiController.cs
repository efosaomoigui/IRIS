using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace IRIS.BCK.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class BaseApiController : ControllerBase
    {
        private IMediator mediator;

        protected IMediator _mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();  

        protected ActionResult HandleQueryResult<T>(T result) where T:class 
        {
            if (result != null) return Ok(result);
            return BadRequest(result);
        }

        protected string GetUserId()
        {
            var user = HttpContext.User.Claims.ToArray();
            var userid = user[0].Value;
            return userid;
        }

        protected ActionResult HandleCommandResult<T>(T result) where T : Application.Responses.BaseResponse
        {
            if (result.Success) return Ok(result.ValidationErrors);
            return BadRequest(result);
        }
    }

}
