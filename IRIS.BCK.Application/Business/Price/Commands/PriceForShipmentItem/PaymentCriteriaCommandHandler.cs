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
        private IShipmentRepository _shipmentRepository; 
        private ITrackHistoryRepository _trackHistoryRepository;
        private IMediator _mediator;
        private string _user;

        public PaymentCriteriaCommandHandler(IPriceEntRepository priceRepository, IWalletTransactionRepository
            walletTransactionRepository, IMapper mapper, IEmailService emailService, UserManager<User> userManager,
            INumberEntRepository numberEntRepository = null, IInvoiceRepository invoiceRepository = null,
            IShipmentRepository shipmentRepository = null, IMediator mediator = null
, ITrackHistoryRepository trackHistoryRepository = null)
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
                var currentUser =
                PaymentCriteriaCommandResponse = new PaymentCriteriaCommandResponse();
                PaymentCriteriaCommandResponse.PaymentStatus = false;

                //convert the jsonstring in values from UI
                var jsonString = request.Values.ToString();
                var resultValues = JsonConvert.DeserializeObject<Values>(jsonString);
                resultValues.shipmentCategory = (resultValues.shipmentCategory == "mailandparcel") ? "MailAndParcel" : resultValues.shipmentCategory;

                //get waybill and invoice code from request
                request.InvoiceNumber = resultValues.invoiceNumber;
                request.WaybillNumber = resultValues.waybillNumber;

                var ShipperUser = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == resultValues.shipperPhoneNumber);
                Guid newUserId = new Guid();

                //check for new or old user
                if (ShipperUser == null)
                {
                    var userCommand = UserMapsCommand.CreateShipperMapsCommand(resultValues);
                    var newUser = await _mediator.Send(userCommand);
                    newUserId = newUser.Userdto.UserId;
                    request.UserId = newUser.Userdto.UserId;
                }
                else
                {
                    request.UserId = (ShipperUser != null) ? ShipperUser.UserId : newUserId;
                }

                //check for new or old reciever
                var RecieverUser = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == resultValues.receiverPhoneNumber);
                if (RecieverUser == null)
                {
                    var receiverCommand = UserMapsCommand.CreateReceiverMapsCommand(resultValues);
                    var newReceiver = await _mediator.Send(receiverCommand);

                    request.Reciever = newReceiver.Userdto.UserId;
                    RecieverUser = _mapper.Map<User>(newReceiver.Userdto);
                }
                else
                {
                    request.Reciever = RecieverUser.UserId;
                }

                //start shipment creation process
                if (request.PaymentMethod == PaymentMethod.Wallet)
                {
                    //create invoice
                    var invoiceResult = await CreateInvoice(request);

                    //do create shipment
                    if (invoiceResult)
                    {
                        var shipmentResult = await CreateShipment(request, resultValues);
                        if (shipmentResult > 0)
                        {
                            var walletResult = await doWalletPayment(request);
                            PaymentCriteriaCommandResponse.PaymentStatus = walletResult.Item1;

                            if (PaymentCriteriaCommandResponse.PaymentStatus)
                            {
                                UpdateInvoice(request);
                            }
                        }

                        //semd email
                        var emailOptions = new EmailOptions();
                        emailOptions.Shipment = resultValues;
                        if (emailOptions != null) await _emailService.SendEmail(email, emailOptions);
                    }
                }
                else if (request.PaymentMethod == PaymentMethod.PostPaid)
                {
                    //create invoice
                    var invoiceResult = await CreateInvoice(request);

                    //do create shipment
                    if (invoiceResult)
                    {
                        var shipmentResult = await CreateShipment(request, resultValues);
                        if (shipmentResult > 0)
                        {
                            //var walletResult = doWalletPayment(request);
                            PaymentCriteriaCommandResponse.PaymentStatus = true;
                        }

                        PaymentCriteriaCommandResponse.PaymentStatus = true;

                        //semd email
                        var emailOptions = new EmailOptions();
                        emailOptions.Shipment = resultValues;
                        if (emailOptions != null) await _emailService.SendEmail(email, emailOptions);
                    }
                    PaymentCriteriaCommandResponse.PaymentStatus = true;
                }
                else if (request.PaymentMethod == PaymentMethod.CreditCard)
                {
                    PaymentCriteriaCommandResponse.PaymentStatus = true;
                }
                else if (request.PaymentMethod == PaymentMethod.USSD)
                {
                    PaymentCriteriaCommandResponse.PaymentStatus = true;

                }
                else if (request.PaymentMethod == PaymentMethod.Cash)
                {
                    PaymentCriteriaCommandResponse.PaymentStatus = true;
                }
            }

            return PaymentCriteriaCommandResponse;
        }

        public async Task<double> CreateShipment(PaymentCriteriaCommand request, Values resultValues)
        {
            var shipmentAmt = 0.0d;

            if (request.UserId.ToString() != null)
            {
                //prepare shipment entries
                var shipment = ShipmentMapsCommand.CreateShipmentValuesMapsCommand(request);
                shipment.Waybill = request.WaybillNumber;

                ShipmentCategory category;
                Enum.TryParse(resultValues.shipmentCategory, out category);

                //do shipment items insert
                shipment.ShipmentItems = new List<ShipmentItem>();

                if (category == ShipmentCategory.TruckLoad)
                {
                    for (var i = 0; i < resultValues.itemsA.Count; i++)
                    {
                        var lineItems = new ShipmentItem();
                        lineItems.Weight = resultValues.itemsA[i].ton;
                        lineItems.length = 0;
                        lineItems.Weight = 0;
                        lineItems.Height = 0;
                        lineItems.ShipmentDescription = resultValues.itemsA[i].t_shipmentDescription;
                        lineItems.ShipmentProduct = resultValues.itemsA[i].t_shipmentType;
                        lineItems.ClientWaybill = resultValues.itemsA[i].t_clientWaybill;
                        lineItems.LineTotal = resultValues.itemsA[i].LineTotal;
                        shipment.ShipmentItems.Add(lineItems);
                    }
                }
                else if (category == ShipmentCategory.MailAndParcel || category == ShipmentCategory.InternationalFreight)
                {
                    for (var i = 0; i < resultValues.itemsB.Count; i++)
                    {
                        var lineItems = new ShipmentItem();
                        lineItems.Weight = resultValues.itemsB[i].weight;
                        lineItems.length = resultValues.itemsB[i].length;
                        lineItems.breadth = resultValues.itemsB[i].breadth;
                        lineItems.Height = resultValues.itemsB[i].height;
                        lineItems.ShipmentDescription = resultValues.itemsB[i].m_shipmentDescription;
                        lineItems.ShipmentProduct = ProductEnum.MailAndParcel;
                        lineItems.LineTotal = resultValues.itemsB[i].LineTotal;
                        shipment.ShipmentItems.Add(lineItems);
                    }
                }

                //check existing shipment
                var shipmentExit = _shipmentRepository.GetAllAsync().Result.FirstOrDefault(x => x.Waybill == request.WaybillNumber);

                //do shipment insert
                if (shipmentExit == null)
                {
                    shipment.CustomerName = resultValues.shipperFullName;
                    shipment.RecieverName = resultValues.receiverFullName;
                    shipment.RecieverAddress = resultValues.receiverAddress;
                    shipment.CustomerAddress = resultValues.shipperAddress;
                    shipment.ShipmentRouteId = new Guid(resultValues.route);
                    shipment.Customer = request.UserId;
                    shipment.Reciever = request.Reciever;
                    shipment.ShipmentProcessingStatus = ShipmentProcessingStatus.Created;
                    ShipmentCategory shipmentCat;
                    Enum.TryParse(resultValues.shipmentCategory, out shipmentCat);
                    shipment.ShipmentCategory = shipmentCat;
                    var shipmentval = await _shipmentRepository.AddAsync(shipment);

                    //add first track
                    var track = TrackHistoryMapsCommand.CreateTrackHistoryMapsCommandInit(request);
                    track = await _trackHistoryRepository.AddAsync(track);

                    return shipment.GrandTotal;
                }
            }

            return shipmentAmt;
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

        public async Task<bool> CreateInvoice(PaymentCriteriaCommand request)
        {
            var invoiceMap = PaymentMapsCommand.CreatePaymentValuesMapsCommand(request);
            var invoiceExit = _invoiceRepository.GetAllAsync().Result.FirstOrDefault(x => x.InvoiceCode == request.InvoiceNumber);

            if (invoiceExit == null)
            {
                await _invoiceRepository.AddAsync(invoiceMap);
                return true;
            }

            return false;
        }

        public async void UpdateInvoice(PaymentCriteriaCommand request)
        {
            //update invoice
            var invoiceExitCheckt = _invoiceRepository.GetAllAsync().Result.FirstOrDefault(x => x.InvoiceCode == request.InvoiceNumber);
            if (invoiceExitCheckt != null)
            {
                invoiceExitCheckt.PaymentMethod = PaymentMethod.Wallet;
                invoiceExitCheckt.Status = StatusEnum.Paid;
                await _invoiceRepository.UpdateAsync(invoiceExitCheckt);
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