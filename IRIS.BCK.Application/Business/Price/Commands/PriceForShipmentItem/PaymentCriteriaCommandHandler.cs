using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Price;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using IRIS.BCK.Core.Application.Mappings.Price;
using IRIS.BCK.Core.Application.Mappings.Wallets;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem
{
    public class PaymentCriteriaCommandHandler : IRequestHandler<PaymentCriteriaCommand, PaymentCriteriaCommandResponse> 
    {
        private readonly IPriceEntRepository _priceRepository;
        private readonly IWalletTransactionRepository _walletTransactionRepository;
        private readonly IPaymentRepository _paymentRepository;
        //private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService; 

        public PaymentCriteriaCommandHandler(IPriceEntRepository priceRepository, IWalletTransactionRepository walletTransactionRepository, IMapper mapper, IEmailService emailService)
        {
            _priceRepository = priceRepository;
            _walletTransactionRepository = walletTransactionRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<PaymentCriteriaCommandResponse> Handle(PaymentCriteriaCommand request, CancellationToken cancellationToken)
        {
            var PaymentCriteriaCommandResponse = new PaymentCriteriaCommandResponse();

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (PaymentCriteriaCommandResponse.Success)
            {
                PaymentCriteriaCommandResponse.paymentData = new PaymentCriteriaCommand();

                if (request.PaymentMethod == PaymentMethod.Wallet)
                {
                    var walletTransaction = WalletTransactionsMapsCommand.CreateWalletTransactionsCriteriaMapsCommand(request);
                    walletTransaction = _walletTransactionRepository.AddAsync(walletTransaction).Result;
                    if (walletTransaction != null)
                    {
                        PaymentCriteriaCommandResponse.paymentData.PaymentStatus = true;
                    }
                }
                else if (request.PaymentMethod == PaymentMethod.PostPaid)
                {
                    PaymentCriteriaCommandResponse.paymentData.PaymentStatus = true;
                }
                else if (request.PaymentMethod == PaymentMethod.CreditCard)
                {
                    PaymentCriteriaCommandResponse.paymentData.PaymentStatus = true;
                }
                else if (request.PaymentMethod == PaymentMethod.USSD)
                {
                    PaymentCriteriaCommandResponse.paymentData.PaymentStatus = true;

                }
                else if (request.PaymentMethod == PaymentMethod.Cash)
                {
                    PaymentCriteriaCommandResponse.paymentData.PaymentStatus = true;
                }

            }

            return PaymentCriteriaCommandResponse;
        }
    }

}