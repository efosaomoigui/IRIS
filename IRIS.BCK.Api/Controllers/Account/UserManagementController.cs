using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateAuthCredentials;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateClaimForRole;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateRole;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUserRole;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.UpdateUsers;
using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetClaimForRole;
using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetRoles;
using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetShipmentList;
using IRIS.BCK.Core.Application.DTO.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.Account
{
    public class UserManagementController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<CreateUserCommandResponse>> Authenticate([FromBody] CreateAuthCredentialsCommand loginCredentials)
        {
            var response = await _mediator.Send(loginCredentials);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<CreateUserCommandResponse>> Create([FromBody] CreateUserCommand createUserCommand)
        {
            var response = await _mediator.Send(createUserCommand);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPut("UpdateUser")]
        public async Task<ActionResult<UpdateUserCommandResponse>> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            var response = await _mediator.Send(updateUserCommand);
            return Ok(response);
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserListViewModel>>> GetAllUsers()
        {
            var users = await _mediator.Send(new GetUserListQuery());
            return Ok(users);
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<UserViewModel>> GetUser()
        {
            var userid = HttpContext.User.FindFirstValue("UserId");
            var user = new UserViewModel();

            if (userid != null)
            {
                user = await _mediator.Send(new GetUserQuery(userid));
            }

            return Ok(user);
        }

        [HttpGet("GetUser/{userid}")]
        public async Task<ActionResult<UserViewModel>> GetUserById([FromRoute] Guid userid)
        {
            //var userid = HttpContext.User.FindFirstValue("UserId");
            var user = new UserViewModel();

            if (userid != null)
            {
                user = await _mediator.Send(new GetUserQuery(userid.ToString()));
            }

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("AddRole")]
        public async Task<ActionResult<CreateRoleCommandResponse>> AddRole([FromBody] CreateRoleCommand createroleCommand)
        {
            var role = await _mediator.Send(createroleCommand);
            return Ok(role);
        }

        [AllowAnonymous]
        [HttpGet("GetRoles")]
        public async Task<ActionResult<List<RoleListViewModel>>> GetAllRoles()
        {
            var roles = await _mediator.Send(new GetRoleListQuery());
            return Ok(roles);
        }

        [HttpPost("AddPermissionToRole")]
        public async Task<ActionResult<CreateClaimForRoleCommandResponse>> AddClaimToRole([FromBody] CreateClaimForRoleCommand createclaimforroleCommand)
        {
            var roleclaim = await _mediator.Send(createclaimforroleCommand);
            return Ok(roleclaim);
        }

        [HttpGet("GetPermissions")]
        public async Task<ActionResult<ClaimViewModel>> GetPermissions()
        {
            var roleid = HttpContext.User.FindFirstValue("RoleId");
            var role = new ClaimViewModel();

            if (roleid != null)
            {
                role = await _mediator.Send(new GetClaimForRoleQuery(roleid));
            }

            return Ok(role);
        }

        [HttpGet("Permissions/GetPermissionsByRoleId/{roleid}")]
        public async Task<ActionResult<List<ClaimViewModel>>> GetPermissionsById(string roleid)
        {
            var permissions = await _mediator.Send(new GetClaimForRoleQuery(roleid));
            return Ok(permissions);
        }

        [AllowAnonymous]
        [HttpPost("AddUserToRole")]
        public async Task<ActionResult<CreateUserRoleCommandResponse>> AddUserToRole([FromBody] CreateUserRoleCommand createuserroleCommand)
        {
            var roleclaim = await _mediator.Send(createuserroleCommand);
            return Ok(roleclaim);
        }
    }
}