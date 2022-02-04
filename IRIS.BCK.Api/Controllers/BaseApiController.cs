using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace IRIS.BCK.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class BaseApiController : ControllerBase
    {
        private IMediator mediator;

        protected IMediator _mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();  
    }

}
