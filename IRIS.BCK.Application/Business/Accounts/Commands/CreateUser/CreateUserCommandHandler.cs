using AutoMapper;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.DTO.Account;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IAccount;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IEmailService emailService, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var CreateUserCommandResponse = new CreateUserCommandResponse();
            var validator = new CreateUserCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                CreateUserCommandResponse.Success = false;
                CreateUserCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateUserCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateUserCommandResponse.Success)
            {
                //var user = _mapper.Map<User>(request);
                var user = new User()
                {
                    UserName = request.Username,
                    Password = request.Password,
                    Email = request.Email
                };

                //user = await _userRepository.AddAsync(user);
                var result =  await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    try
                    {
                        await _emailService.SendEmail(email);
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
                        CreateUserCommandResponse.ValidationErrors.Add(error.Description);
                    }
                }

                CreateUserCommandResponse.Userdto = _mapper.Map<UserDto>(user);
            }

            return CreateUserCommandResponse;
        }
    }
}
