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
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

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
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Email = request.Email;
                user.PhoneNumber = request.PhoneNumber;
                if (request.requirePasswordChanged == "Yes")
                {

                    await _userManager.ChangePasswordAsync(user, user.Password, request.Password);
                    user.Password = request.Password;
                }
                var updateUser = _mapper.Map<User>(user);
                await _userManager.UpdateAsync(updateUser);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception ex)
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

    public class UpdateUserConfirmationCommandHandler : IRequestHandler<UpdateUserConfirmationCommand, UpdateUserCommandResponse>
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UpdateUserConfirmationCommandHandler(IUserRepository userRepository, IMapper mapper, IEmailService emailService, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserConfirmationCommand request, CancellationToken cancellationToken)
        {
            var UpdateUserCommandResponse = new UpdateUserCommandResponse();

            var user = await _userManager.FindByIdAsync(request.Userid.ToString());
            if (user == null)
            {
                UpdateUserCommandResponse.ValidationErrors.Add("User does not exist!");
                return UpdateUserCommandResponse;
            }

            var updateUser = _mapper.Map<User>(user);
            var token2 = HttpUtility.UrlDecode(request.Token);
            var result = await _userManager.ConfirmEmailAsync(user, request.Token);

            if (!result.Succeeded)
            {
                UpdateUserCommandResponse.ValidationErrors.Add("Email Confirmation Failed!");

                if (user.UserType == UserType.Corporate)
                {
                    await _userManager.AddToRoleAsync(user, "Individual");
                }

                if (user.UserType == UserType.Corporate)
                {
                    await _userManager.AddToRoleAsync(user, "Corporate");
                }

                return UpdateUserCommandResponse;
            }

            UpdateUserCommandResponse.Userdto = _mapper.Map<UserDto>(updateUser);
            UpdateUserCommandResponse.Userdto.ConfirmEmail = true;
            return UpdateUserCommandResponse;
        }
    }

}
