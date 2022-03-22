using AutoMapper;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Price;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using IRIS.BCK.Core.Application.Mappings.Price;
using IRIS.BCK.Core.Application.Mappings.Wallets;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly IInvoiceRepository _paymentRepository;
        //private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;
        private INumberEntRepository _numberEntRepository;
        private IInvoiceRepository _invoiceRepository;

        public PaymentCriteriaCommandHandler(IPriceEntRepository priceRepository, IWalletTransactionRepository walletTransactionRepository, IMapper mapper, IEmailService emailService, UserManager<User> userManager, INumberEntRepository numberEntRepository = null, IInvoiceRepository invoiceRepository = null)
        {
            _priceRepository = priceRepository;
            _walletTransactionRepository = walletTransactionRepository;
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
            _numberEntRepository = numberEntRepository;
            _invoiceRepository = invoiceRepository;
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
                    request.CustomerPhoneNumber = "0" + request.CustomerPhoneNumber;
                    var ShipperUser = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == request.CustomerPhoneNumber);
                    request.UserId = ShipperUser?.UserId; //replace default userid from ui

                    if (request.UserId != null)
                    {
                        //add wallet transactions
                        var walletTransaction = WalletTransactionsMapsCommand.CreateWalletTransactionsCriteriaMapsCommand(request);
                        walletTransaction = _walletTransactionRepository.WalletDebit(walletTransaction).Result;

                        //genenerate invoicecode
                        var invoiceCode = _numberEntRepository.GenerateNextNumber(NumberGeneratorType.InvoiceNumber, "101").Result;
                        await _invoiceRepository.AddAsync(new Invoice
                        {
                            InvoiceCode = invoiceCode,
                            am
                        });

                        if (walletTransaction != null)
                        {


                            PaymentCriteriaCommandResponse.paymentData.PaymentStatus = true;
                        }
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