using AutoMapper;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateRole;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUserRole;
using IRIS.BCK.Core.Application.DTO.Account;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IAccount;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using IRIS.BCK.Core.Application.Mappings.Users;
using IRIS.BCK.Core.Application.Shared;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IWalletRepository _walletRepository;
        private INumberEntRepository _numberEntRepository;
        public IConfiguration Configuration;
        private IMediator _mediator;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IEmailService emailService, UserManager<User> userManager, IWalletRepository walletRepository, INumberEntRepository numberEntRepository = null, IConfiguration configuration = null, IMediator mediator = null, RoleManager<AppRole> roleManager = null)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
            _walletRepository = walletRepository;
            _numberEntRepository = numberEntRepository;
            Configuration = configuration;
            _mediator = mediator;
            _roleManager = roleManager;
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

            var body = "<p>Welcome to Iris</p>";
            body += "Welcome to Iris";
            var subject = "Confirmation Email";
            var email = UserMapsCommand.CreateUserEmailMessage(request.Email, body, subject);

            if (CreateUserCommandResponse.Success)
            {
                var user = UserMapsCommand.CreateUserMapsCommand(request);
                //user = await _userRepository.AddAsync(user);

                var userExist = await _userManager.FindByNameAsync(user.UserName) ?? await _userManager.FindByEmailAsync(user.UserName);
                var existUserPhone = await _userRepository.GetAllAsync();
                var exitPhone = existUserPhone.FirstOrDefault(x => x.PhoneNumber == request.PhoneNumber);

                if (userExist == null && exitPhone ==null)
                {
                    //generate last Wallet number
                    var walletNumber = _walletRepository.GetWalletNumber("101"); 
                    user.WalletNumber = walletNumber;
                    user.UserId = new Guid(user.Id);
                    var result = await _userManager.CreateAsync(user, user.Password);

                    if (result.Succeeded)
                    {
                        try
                        {
                            var wallet = new WalletNumber()
                            {
                                Id = new Guid(),
                                WalletBalance = 0.0M,
                                Number = walletNumber,
                                UserId = user.UserId,
                                IsActive = true
                            };

                            await _walletRepository.AddAsync(wallet);
                            //await _emailService.SendEmail(email);

                            //assign default individual customer role to user CreateUserRoleCommand
                            var roleToUser = new CreateUserRoleCommand();
                            roleToUser.UserId = user.UserId.ToString();

                            var role = await _roleManager.FindByNameAsync("Personal");
                            roleToUser.RoleId = new string[1];
                            roleToUser.RoleId[0] = role.Name;

                            var claim = new Claim("ServiceCenter", "101");
                            var claimResult = await _userManager.AddClaimAsync(user, claim);

                            var newUser = await _mediator.Send(roleToUser);

                            //generate confirmation
                            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                            var token2 = HttpUtility.UrlEncode(token); // encoded because the url need to preserve space with +, but do not need decoding on confirmemail

                            //send email
                            var emailOptions = new EmailOptions();
                            emailOptions.toEmail = request.Email;
                            emailOptions.confirmationLink = Configuration["UiUrlCustomer"] +"/confirmEmail?userId=" + user.UserId+"&token="+ token2;
                            emailOptions.CustomerName = user.FirstName;

                            if (email.To != "")
                            {
                                emailOptions.templateId = Configuration["ConfirmationEmailTemplateId"];
                                if (emailOptions != null) await _emailService.SendConfirmationEmail(email, emailOptions);
                            }
                        }
                        catch (Exception ex)
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
                else
                {
                    CreateUserCommandResponse.ValidationErrors.Add(StaticMessages.UserExist);
                }
            }

            return CreateUserCommandResponse;
        }
    }
}