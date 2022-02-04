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
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateClaimForRole 
{
    public class CreateClaimForRoleCommandHandler : IRequestHandler<CreateClaimForRoleCommand, CreateClaimForRoleCommandResponse>
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IRoleClaimRepository _roleClaimRepository;   
        private readonly RoleManager<AppRole> _roleManager;  

        public CreateClaimForRoleCommandHandler(IUserRepository userRepository, IMapper mapper, IEmailService emailService, RoleManager<AppRole> roleManager,
            IRoleClaimRepository roleClaimRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
            _roleManager = roleManager;
            _roleClaimRepository = roleClaimRepository;
        }

        public async Task<CreateClaimForRoleCommandResponse> Handle(CreateClaimForRoleCommand request, CancellationToken cancellationToken)
        {
            var CreateClaimForRoleCommandResponse = new CreateClaimForRoleCommandResponse();
            var validator = new CreateClaimForRoleCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                CreateClaimForRoleCommandResponse.Success = false;
                CreateClaimForRoleCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateClaimForRoleCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var body = "message to user";
            var subject = "Subject to email";
            //var email = UserMapsCommand.CreateUserEmailMessage(request.Email, body, subject);

            if (CreateClaimForRoleCommandResponse.Success)
            {
                var role = UserMapsCommand.CreateClaimForRoleMapsCommand(request);
                var roleExist = await _roleManager.FindByIdAsync(role.RoleId);
                var result = new IdentityResult();

                if (roleExist != null)
                {
                    var claims = (await _roleClaimRepository.GetAllAsync()).ToList().FirstOrDefault(x => x.ClaimValue == request.ClaimValue);
                    if(claims == null) { 
                    var newClaim = new Claim(request.ClaimType, request.ClaimValue);
                        result = await _roleManager.AddClaimAsync(roleExist, newClaim);
                    }
                    else
                    {
                        CreateClaimForRoleCommandResponse.ValidationErrors.Add(StaticMessages.RoleClaimExist);
                        return CreateClaimForRoleCommandResponse;
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
                            CreateClaimForRoleCommandResponse.ValidationErrors.Add(error.Description);
                        }
                    }

                    CreateClaimForRoleCommandResponse.roledto = _mapper.Map<ClaimRoleDto>(role);
                }
                else
                {
                    CreateClaimForRoleCommandResponse.ValidationErrors.Add(StaticMessages.RoleExist);
                }
            }

            return CreateClaimForRoleCommandResponse;
        }
    }
}
