using AutoMapper;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using IRIS.BCK.Core.Application.DTO.Account;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IAccount;
using IRIS.BCK.Core.Application.Mappings.Users;
using IRIS.BCK.Core.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUserRole
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, CreateUserRoleCommandResponse>
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public CreateUserRoleCommandHandler(IUserRepository userRepository, IMapper mapper, IEmailService emailService, RoleManager<AppRole> roleManager, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<CreateUserRoleCommandResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var CreateUserRoleCommandResponse = new CreateUserRoleCommandResponse();
            var validator = new CreateUserRoleCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                CreateUserRoleCommandResponse.Success = false;
                CreateUserRoleCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateUserRoleCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var body = "message to user";
            var subject = "Subject to email";

            if (CreateUserRoleCommandResponse.Success)
            {
                var role = UserMapsCommand.CreateUserRoleMapsCommand(request);
                var user = await _userManager.FindByIdAsync(request.UserId);
                var roleexist = _userManager.GetRolesAsync(user).Result.ToArray();
                var result = new IdentityResult();

                foreach (var roleitem in request.RoleId)
                {
                    if (roleexist.Contains(roleitem))
                    {
                        await _userManager.RemoveFromRolesAsync(user, roleexist);
                    }

                    result = await _userManager.AddToRoleAsync(user, roleitem);
                }


                if (result.Succeeded)
                {
                    try
                    {
                        //await _emailService.SendEmail(email);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        CreateUserRoleCommandResponse.ValidationErrors.Add(error.Description);
                    }
                }

                CreateUserRoleCommandResponse.roledto = _mapper.Map<UserRoleDto>(role);

            }

            return CreateUserRoleCommandResponse;
        }
    }
}
