using AutoMapper;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using IRIS.BCK.Core.Application.DTO.Account;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IAccount;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
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

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.UpdateUsers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IEmailService emailService, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var UpdateUserCommandResponse = new UpdateUserCommandResponse();
            var validator = new UpdateUserCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdateUserCommandResponse.Success = false;
                UpdateUserCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateUserCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdateUserCommandResponse.Success)
            {
                var updateUser = _mapper.Map<User>(request);
                await _userManager.UpdateAsync(updateUser);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdateUserCommandResponse.Userdto = _mapper.Map<UserDto>(updateUser);

                return UpdateUserCommandResponse;
            }

            UpdateUserCommandResponse.Userdto = new UserDto();
            return UpdateUserCommandResponse;
        }
    }
}

//            if (UpdateUserCommandResponse.Success)
//            {
//                var user = UserMapsCommand.UpdateUserMapsCommand(request);
//                //user = await _userRepository.AddAsync(user);

//                var userExist = await _userManager.FindByIdAsync(user.Id);
//                if (userExist == null)
//                {
//                    var result = await _userManager.UpdateAsync(userExist);

//                    if (result.Succeeded)
//                    {
//                        try
//                        {
//                            //await _emailService.SendEmail(email);
//                        }
//                        catch (Exception)
//                        {
//                            throw;
//                        }
//                    }
//                    else
//                    {
//                        foreach (var error in result.Errors)
//                        {
//                            UpdateUserCommandResponse.ValidationErrors.Add(error.Description);
//                        }
//                    }

//                    UpdateUserCommandResponse.Userdto = _mapper.Map<UserDto>(user);
//                }
//                else
//                {
//                    UpdateUserCommandResponse.ValidationErrors.Add(StaticMessages.UserExist);
//                }
//            }

//            return UpdateUserCommandResponse;
//        }
//    }
//}