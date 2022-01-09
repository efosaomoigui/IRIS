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

        [HttpPost(Name = "Login")]
        public Task<ActionResult<CreateUserCommandResponse>> Authenticate([FromBody] LoginCredentialsModelDto loginCredentials) 
        {

            //Try to get the user from the database
            if (loginCredentials.UserName == "efe" && loginCredentials.Password == "fineboy20x")
            {
                var claims = new List<Claim> { 
                    new Claim(ClaimTypes.Name, "Admin"),
                    new Claim(ClaimTypes.Email, "Admin@chiscoexpress.com"),
                    new Claim("Department", "IT")
                };
            }

            var expiresAt = DateTime.UtcNow.AddMinutes(10);
            return null;


            //if he doesnt exit, return unathourize

            //if he does exist call, get his claims from the db if he has 

            //if he doesnt have claims return unauthorize

            //if he does take the claims and expirationdate and generate a token

            //return the token to the user


        }

        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<CreateUserCommandResponse>> Create([FromBody] CreateUserCommand createUserCommand)
        {
            var response = await _mediator.Send(createUserCommand);
            return Ok(response);
        }
    }
}
