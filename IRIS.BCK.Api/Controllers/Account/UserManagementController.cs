using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateAuthCredentials;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using IRIS.BCK.Core.Application.DTO.Account;
using MediatR;
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

        [HttpPost("AddLogin")]
        public async Task<ActionResult<CreateUserCommandResponse>> Authenticate([FromBody] CreateAuthCredentialsCommand loginCredentials)
        {
            var response = await _mediator.Send(loginCredentials);
            return Ok(response);
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<CreateUserCommandResponse>> Create([FromBody] CreateUserCommand createUserCommand)
        {
            var response = await _mediator.Send(createUserCommand);
            return Ok(response);
        }
    }
}
