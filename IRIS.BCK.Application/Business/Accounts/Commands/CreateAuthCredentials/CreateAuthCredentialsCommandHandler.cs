using AutoMapper;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IAccount;
using MediatR;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using IRIS.BCK.Core.Application.DTO.Account;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateAuthCredentials
{
    public class CreateAuthCredentialsCommandHandler : IRequestHandler<CreateAuthCredentialsCommand, CreateAuthCredentialsCommandResponse>
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager; 

        private readonly IConfiguration _config;

        public CreateAuthCredentialsCommandHandler(IUserRepository userRepository, IMapper mapper, IEmailService emailService, IConfiguration config, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
            _config = config;
            _userManager = userManager;
        }

        public async Task<CreateAuthCredentialsCommandResponse> Handle(CreateAuthCredentialsCommand request, CancellationToken cancellationToken)
        {
            var createAuthCredentialsCommandResponse = new CreateAuthCredentialsCommandResponse();
            var validator = new CreateAuthCredentialsCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createAuthCredentialsCommandResponse.Success = false;
                createAuthCredentialsCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    createAuthCredentialsCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (createAuthCredentialsCommandResponse.Success)
            {
                // Verify the credential
                var user = await _userManager.FindByNameAsync(request.UserName) ?? await _userManager.FindByEmailAsync(request.UserName);
                var result = await _userManager.CheckPasswordAsync(user, request.Password);

                if (result)
                {
                    // Creating the security context
                    var claims = await _userManager.GetClaimsAsync(user);
                    var expiresAt = DateTime.UtcNow.AddMinutes(10);

                    //Add claims based on the role
                    var newclaim = new Claim("UserId", user.UserId.ToString()); 
                    claims.Add(newclaim);

                    createAuthCredentialsCommandResponse.AccessToken = CreateToken(claims, expiresAt);
                    createAuthCredentialsCommandResponse.ExpireAt = expiresAt;

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
                    createAuthCredentialsCommandResponse.ValidationErrors.Add("You are not authorized to access this endpoint.");
                }
            }

            return createAuthCredentialsCommandResponse;
        }

        private string CreateToken(IEnumerable<Claim> claims, DateTime expiresAt)
        {
            var secretKey = Encoding.ASCII.GetBytes(_config["SecretKey"]);

            var jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiresAt,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
