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

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreateRoleCommandResponse>
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly RoleManager<AppRole> _roleManager; 

        public CreateRoleCommandHandler(IUserRepository userRepository, IMapper mapper, IEmailService emailService, RoleManager<AppRole> roleManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var CreateRoleCommandResponse = new CreateRoleCommandResponse();
            var validator = new CreateRoleCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                CreateRoleCommandResponse.Success = false;
                CreateRoleCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateRoleCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var body = "message to user";
            var subject = "Subject to email";
            //var email = UserMapsCommand.CreateUserEmailMessage(request.Email, body, subject);

            if (CreateRoleCommandResponse.Success)
            {
                var role = UserMapsCommand.CreateRoleMapsCommand(request);
                var roleExist = await _roleManager.FindByNameAsync(role.Name);

                if (roleExist == null)
                {
                    var result = await _roleManager.CreateAsync(role);

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
                            CreateRoleCommandResponse.ValidationErrors.Add(error.Description);
                        }
                    }

                    CreateRoleCommandResponse.roledto = _mapper.Map<RoleDto>(role);
                }
                else
                {
                    CreateRoleCommandResponse.ValidationErrors.Add(StaticMessages.RoleExist);
                }
            }

            return CreateRoleCommandResponse;
        }
    }
}
