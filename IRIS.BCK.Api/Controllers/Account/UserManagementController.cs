using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateAuthCredentials;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using IRIS.BCK.Core.Application.DTO.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.Account
{
    public class UserManagementController : BaseApiController
    {
        private readonly IMediator _mediator;
        public UserManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<CreateUserCommandResponse>> Authenticate([FromBody] CreateAuthCredentialsCommand loginCredentials)
        {
            var response = await _mediator.Send(loginCredentials);
            return Ok(response);  //test file
        }

        [HttpPost("Register")]
        public async Task<ActionResult<CreateUserCommandResponse>> Create([FromBody] CreateUserCommand createUserCommand)
        {
            var response = await _mediator.Send(createUserCommand);
            return Ok(response);
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<CreateUserCommandResponse>> GetUsers([FromBody] CreateUserCommand createUserCommand)
        {
            var response = await _mediator.Send(createUserCommand); 
            return Ok(response);
        }
    }
}
