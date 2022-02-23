﻿using AutoMapper;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using IRIS.BCK.Core.Application.DTO.Account;
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
        private readonly IWalletRepository _walletRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IEmailService emailService, UserManager<User> userManager, IWalletRepository walletRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
            _walletRepository = walletRepository;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var UpdateUserCommandResponse = new UpdateUserCommandResponse();

            var validator = new UpdateUserCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                UpdateUserCommandResponse.Success = false;
                UpdateUserCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateUserCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var body = "message to user";
            var subject = "Subject to email";
            var email = UserMapsCommand.CreateUserEmailMessage(request.Email, body, subject);

            if (UpdateUserCommandResponse.Success)
            {
                var user = UserMapsCommand.UpdateUserMapsCommand(request);
                //user = await _userRepository.AddAsync(user);

                var userExist = await _userManager.FindByNameAsync(user.UserName) ?? await _userManager.FindByEmailAsync(user.UserName);

                if (userExist == null)
                {
                    //generate last Wallet number
                    var wallet = _walletRepository.GetWalletNumber();
                    wallet = user.WalletNumber.ToString();

                    //generate a wallet number ---> getwallnumber
                    //var walletnumber = 0000000000;
                    //user.WalletNumber = walletnumber;
                    var result = await _userManager.UpdateAsync(user);

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
                            UpdateUserCommandResponse.ValidationErrors.Add(error.Description);
                        }
                    }

                    UpdateUserCommandResponse.Userdto = _mapper.Map<UserDto>(user);
                }
                else
                {
                    UpdateUserCommandResponse.ValidationErrors.Add(StaticMessages.UserExist);
                }
            }

            return UpdateUserCommandResponse;
        }
    }
}