using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Wallet;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using IRIS.BCK.Core.Application.Mappings.Wallets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletTransactionCommand
{
    public class CreateWalletTransactionCommandHandler : IRequestHandler<CreateWalletTransactionCommand, CreateWalletTransactionCommandResponse>
    {
        private readonly IWalletTransactionRepository _walletTransactionRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateWalletTransactionCommandHandler(IWalletTransactionRepository walletTransactionRepository, IMapper mapper, IEmailService emailService)
        {
            _walletTransactionRepository = walletTransactionRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateWalletTransactionCommandResponse> Handle(CreateWalletTransactionCommand request, CancellationToken cancellationToken)
        {
            var CreateWalletTransactionCommandResponse = new CreateWalletTransactionCommandResponse();
            var validator = new CreateWalletTransactionCommandValidator(_walletTransactionRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateWalletTransactionCommandResponse.Success = false;
                CreateWalletTransactionCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateWalletTransactionCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateWalletTransactionCommandResponse.Success)
            {
                var walletTransactionNumber = WalletTransactionsMapsCommand.CreateWalletTransactionsMapsCommand(request);
                walletTransactionNumber = await _walletTransactionRepository.AddAsync(walletTransactionNumber);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateWalletTransactionCommandResponse.WalletTransactiondto = _mapper.Map<WalletTransactionDto>(walletTransactionNumber);

                return CreateWalletTransactionCommandResponse;
            }

            CreateWalletTransactionCommandResponse.WalletTransactiondto = new WalletTransactionDto();
            return CreateWalletTransactionCommandResponse;
        }
    }
}