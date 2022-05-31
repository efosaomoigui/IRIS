using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Price;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using IRIS.BCK.Core.Application.Mappings.Payments;
using IRIS.BCK.Core.Application.Mappings.Price;
using IRIS.BCK.Core.Application.Mappings.Shipments;
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
using Newtonsoft.Json;
using IRIS.BCK.Core.Application.Mappings.Users;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Application.Business.UserResolver;
using IRIS.BCK.Core.Application.Mappings.Monitoring;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IMonitoringRepositories;
using Microsoft.Extensions.Configuration;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.UpdatePaymentCommandHandler
{

    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentPendingCommand, PaymentCriteriaCommandResponse>
    {
        private readonly IPriceEntRepository _priceRepository;
        private readonly IWalletTransactionRepository _walletTransactionRepository;
        private readonly IInvoiceRepository _paymentRepository;
        //private readonly IInvoiceRepository _invoiceRepository;
        public IConfiguration Configuration;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager; 
        private INumberEntRepository _numberEntRepository;
        private IInvoiceRepository _invoiceRepository;
        private IGenericRepository<Invoice> _genericRepository;
        private IShipmentRepository _shipmentRepository;
        private ITrackHistoryRepository _trackHistoryRepository;
        private IMediator _mediator;
        private string _user;

        public UpdatePaymentCommandHandler(IPriceEntRepository priceRepository, IWalletTransactionRepository
            walletTransactionRepository, IMapper mapper, IEmailService emailService, UserManager<User> userManager,
            INumberEntRepository numberEntRepository = null, IInvoiceRepository invoiceRepository = null,
            IShipmentRepository shipmentRepository = null, IMediator mediator = null
, ITrackHistoryRepository trackHistoryRepository = null, IConfiguration configuration = null, IGenericRepository<Invoice> genericRepository = null)
        {
            _priceRepository = priceRepository;
            _walletTransactionRepository = walletTransactionRepository;
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
            _numberEntRepository = numberEntRepository;
            _invoiceRepository = invoiceRepository;
            _shipmentRepository = shipmentRepository;
            _mediator = mediator;
            _trackHistoryRepository = trackHistoryRepository;
            Configuration = configuration;
            _genericRepository = genericRepository;
        }

        public async Task<PaymentCriteriaCommandResponse> Handle(UpdatePaymentPendingCommand request, CancellationToken cancellationToken)
        {
            //convert the jsonstring in values from UI

            //get waybill and invoice code from request
            request.InvoiceNumber = request.InvoiceNumber;
            request.WaybillNumber = request.WaybillNumber;

            var PaymentCriteriaCommandResponse = new PaymentCriteriaCommandResponse(); //check existing shipment
            var shipment = _shipmentRepository.GetAllAsync().Result.FirstOrDefault(x => x.Waybill == request.WaybillNumber);
            var invoiceExit = _invoiceRepository.GetAllAsync().Result.FirstOrDefault(x => x.WaybilNumber == request.WaybillNumber);

            if (invoiceExit != null && shipment != null)
            {
                var email = new Email
                {
                    To = "efe.omoigui@gmail.com",
                    Body = "Test Message",
                    Subject = "Test Email"
                };

                var currentUser =
                PaymentCriteriaCommandResponse = new PaymentCriteriaCommandResponse();
                PaymentCriteriaCommandResponse.PaymentStatus = false;
                var walletRequest = new PaymentCriteriaCommand();
                walletRequest.WaybillNumber = request.WaybillNumber;
                walletRequest.InvoiceNumber = request.InvoiceNumber;
                walletRequest.UserId = shipment.Customer;
                walletRequest.Amount = request.Amount;
                walletRequest.PaymentMethod = request.PaymentMethod;

                //start shipment creation process
                if (request.PaymentMethod == PaymentMethod.Wallet)
                {
                    walletRequest.ShimentCategory = request.ShipmentCategory;

                    var walletResult = await doWalletPayment(walletRequest);
                    PaymentCriteriaCommandResponse.PaymentStatus = walletResult.Item1;
                    PaymentCriteriaCommandResponse.PaymentMethod = PaymentMethod.Wallet;

                    if (PaymentCriteriaCommandResponse.PaymentStatus)
                    {
                        //UpdateInvoice(walletRequest);
                        invoiceExit.PaymentMethod = PaymentMethod.Wallet;
                        invoiceExit.Status = StatusEnum.Paid;
                        await _genericRepository.UpdateAsync(invoiceExit);
                    }

                    //semd email
                    var emailOptions = new EmailOptions();
                    emailOptions.ShipmentDetails = shipment;
                    //emailOptions.toEmail = shipment.
                    if (emailOptions != null) await _emailService.SendEmail(email, emailOptions);
                }
                //start shipment creation process
                if (request.PaymentMethod == PaymentMethod.Receivables || request.PaymentMethod == PaymentMethod.Cash)
                {
                    PaymentCriteriaCommandResponse.PaymentStatus = true;
                    PaymentCriteriaCommandResponse.PaymentMethod = PaymentMethod.Receivables;

                    if (PaymentCriteriaCommandResponse.PaymentStatus)
                    {
                        //UpdateInvoice(walletRequest);
                        invoiceExit.PaymentMethod = PaymentMethod.Wallet;
                        invoiceExit.Status = StatusEnum.Paid;
                        await _genericRepository.UpdateAsync(invoiceExit);
                    }

                    //send email
                    //var emailOptions = new EmailOptions();
                    //emailOptions.ShipmentDetails = shipment;
                    //if (emailOptions != null) await _emailService.SendEmail(email, emailOptions);
                }
                else if (request.PaymentMethod == PaymentMethod.PostPaid)
                {
                    PaymentCriteriaCommandResponse.PaymentStatus = true;
                    PaymentCriteriaCommandResponse.PaymentMethod = PaymentMethod.PostPaid;

                    //semd email
                    var emailOptions = new EmailOptions();
                    emailOptions.ShipmentDetails = shipment;
                    //emailOptions.toEmail = email.To;
                    if (email.To != "")
                    {
                        emailOptions.templateId = Configuration["ShipmentConfirmationTemplateId"]; // "d-b87f6cab7b0a4dd490d026394de53ab7";
                        if (emailOptions != null && email != null) await _emailService.SendEmail(email, emailOptions);
                    }
                }
                else if (request.PaymentMethod == PaymentMethod.CreditCard)
                {
                    PaymentCriteriaCommandResponse.PaymentStatus = true;
                    PaymentCriteriaCommandResponse.PaymentMethod = PaymentMethod.CreditCard;
                }
                else if (request.PaymentMethod == PaymentMethod.USSD)
                {
                    PaymentCriteriaCommandResponse.PaymentStatus = true;
                    PaymentCriteriaCommandResponse.PaymentMethod = PaymentMethod.USSD;

                }
                else if (request.PaymentMethod == PaymentMethod.Cash)
                {
                    PaymentCriteriaCommandResponse.PaymentStatus = true;
                    PaymentCriteriaCommandResponse.PaymentMethod = PaymentMethod.Cash;
                    if (PaymentCriteriaCommandResponse.PaymentStatus)
                    {
                        UpdateInvoice(walletRequest);
                    }
                }
            }

            return PaymentCriteriaCommandResponse;
        }

        public async Task<Tuple<bool, PaymentMethod>> doWalletPayment(PaymentCriteriaCommand request)
        {
            //do wallet payment
            var walletTransaction = WalletTransactionsMapsCommand.CreateWalletTransactionsCriteriaMapsCommand(request);
            walletTransaction = _walletTransactionRepository.WalletDebit(walletTransaction).Result;

            if (walletTransaction != null)
            {
                Tuple<bool, PaymentMethod> tupResult =
                            new Tuple<bool, PaymentMethod>(true, PaymentMethod.Wallet);

                return tupResult;
            }
            return new Tuple<bool, PaymentMethod>(false, PaymentMethod.Wallet);
        }

        public async void UpdateInvoice(PaymentCriteriaCommand request)
        {
            //update invoice
            var invoiceExitCheckt = _genericRepository.GetAllAsync().Result.FirstOrDefault(x => x.InvoiceCode == request.InvoiceNumber);
            if (invoiceExitCheckt != null)
            {
                invoiceExitCheckt.PaymentMethod = PaymentMethod.Wallet;
                invoiceExitCheckt.Status = StatusEnum.Paid;
                await _genericRepository.UpdateAsync(invoiceExitCheckt);
            }
        }

        public string checkPhone(string number)
        {
            var length = number.Length;
            var firstchar = number[0];

            if (length < 11 && firstchar > 0)
            {
                number = "0" + number;
            }

            return number;
        }

    }
}