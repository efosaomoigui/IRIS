using AutoMapper;
using IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletNumberCommand;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Wallet;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using IRIS.BCK.Core.Application.Mappings.Wallets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletNumber
{
    public class CreateWalletNumberCommandHandler : IRequestHandler<CreateWalletNumberCommand, CreateWalletNumberCommandResponse>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateWalletNumberCommandHandler(IWalletRepository walletRepository, IMapper mapper, IEmailService emailService)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateWalletNumberCommandResponse> Handle(CreateWalletNumberCommand request, CancellationToken cancellationToken)
        {
            var CreateWalletNumberCommandResponse = new CreateWalletNumberCommandResponse();
            var validator = new CreateWalletNumberCommandValidator(_walletRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateWalletNumberCommandResponse.Success = false;
                CreateWalletNumberCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateWalletNumberCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateWalletNumberCommandResponse.Success)
            {
                var walletMapExist = await _walletRepository.Get(s => s.Id == request.Id);

                if (walletMapExist == null)
                {
                    var walletNum = WalletsMapsCommand.CreateWalletsMapsCommand(request);
                    walletNum = await _walletRepository.AddAsync(walletNum);

                    if (CreateWalletNumberCommandResponse.Success)
                    {
                        var walletNumber = WalletsMapsCommand.CreateWalletsMapsCommand(request);
                        walletNumber = await _walletRepository.AddAsync(walletNumber);

                        try
                        {
                            await _emailService.SendEmail(email);
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                        CreateWalletNumberCommandResponse.Walletdto = _mapper.Map<WalletNumberDto>(walletNumber);

                        return CreateWalletNumberCommandResponse;
                    }
                }
            }
            CreateWalletNumberCommandResponse.Walletdto = new WalletNumberDto();
            return CreateWalletNumberCommandResponse;
        }
    }
}