using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Wallet;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using IRIS.BCK.Core.Application.Mappings.Wallets;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletTransactionCommand
{
    public class CreditWalletCommandHandler : IRequestHandler<CreditWalletCommand, CreateWalletTransactionCommandResponse>
    {
        private readonly IWalletTransactionRepository _walletTransactionRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreditWalletCommandHandler(IWalletTransactionRepository walletTransactionRepository, IMapper mapper, IEmailService emailService)
        {
            _walletTransactionRepository = walletTransactionRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateWalletTransactionCommandResponse> Handle(CreditWalletCommand request, CancellationToken cancellationToken)
        {
            var CreateWalletTransactionCommandResponse = new CreateWalletTransactionCommandResponse();
            var validator = new CreditWalletCommandValidator(_walletTransactionRepository);
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
                var userId = _walletTransactionRepository.UserIdByWalletNumber(request.WalletNumber).Result;
                request.UserId = new Guid(userId);

                //do wallet transaction
                var walletTransaction = WalletTransactionsMapsCommand.CreateWalletTransactionsMapsCommand(request);
                walletTransaction = _walletTransactionRepository.WalletCredit(walletTransaction).Result;

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateWalletTransactionCommandResponse.WalletTransactiondto = _mapper.Map<WalletTransactionDto>(walletTransaction);

                return CreateWalletTransactionCommandResponse;
            }

            CreateWalletTransactionCommandResponse.WalletTransactiondto = new WalletTransactionDto();
            return CreateWalletTransactionCommandResponse;
        }
    }

    public class CreditWalletCommand : IRequest<CreateWalletTransactionCommandResponse>
    {
        public double Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Description { get; set; }
        public string WalletNumber { get; set; }
        public Guid UserId { get; set; }
    }
}