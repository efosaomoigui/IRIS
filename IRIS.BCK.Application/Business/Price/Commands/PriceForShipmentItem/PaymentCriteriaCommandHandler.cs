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

        public PaymentCriteriaCommandHandler(IPriceEntRepository priceRepository, IWalletTransactionRepository walletTransactionRepository, IMapper mapper, IEmailService emailService, UserManager<User> userManager, INumberEntRepository numberEntRepository = null, IInvoiceRepository invoiceRepository = null, IShipmentRepository shipmentRepository = null)
        {
            _priceRepository = priceRepository;
            _walletTransactionRepository = walletTransactionRepository;
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
            _numberEntRepository = numberEntRepository;
            _invoiceRepository = invoiceRepository;
            _shipmentRepository = shipmentRepository;
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
                    request.UserId = ShipperUser.UserId;

                    if (request.UserId.ToString() != null)
                    {
                        //Waybill for the shipment
                        var WaybillNumber = _numberEntRepository.GenerateNextNumber(NumberGeneratorType.WaybillNumber, "101").Result; 
                        

                        //add wallet transactions
                        var walletTransaction = WalletTransactionsMapsCommand.CreateWalletTransactionsCriteriaMapsCommand(request);
                        walletTransaction = _walletTransactionRepository.WalletDebit(walletTransaction).Result;

                        //genenerate invoicecode
                        var invoiceCode = _numberEntRepository.GenerateNextNumber(NumberGeneratorType.InvoiceNumber, "101").Result;
                        request.InvoiceNumber = invoiceCode;
                        request.WaybillNumber = WaybillNumber;
                        var invoiceMap = PaymentMapsCommand.CreatePaymentValuesMapsCommand(request);
                        await _invoiceRepository.AddAsync(invoiceMap);

                        //create shipment Status = (walletTransaction != null)? StatusEnum.Paid : StatusEnum.Pending
                        var shipment = ShipmentMapsCommand.CreateShipmentValuesMapsCommand(request);
                        shipment.Waybill = WaybillNumber;

                        //convert the jsonstring in values from UI
                        var jsonString = request.Values.ToString();
                        var resultValues = JsonConvert.DeserializeObject<Values>(jsonString);
                        resultValues.shipmentCategory = (resultValues.shipmentCategory == "mailandparcel") ? "MailAndParcel" : resultValues.shipmentCategory;

                        ShipmentCategory category;
                        Enum.TryParse(resultValues.shipmentCategory, out category); 

                        shipment.ShipmentItems = new List<ShipmentItem>();

                        var recieverPhoneNumber = "0" + resultValues.receiverPhoneNumber;
                        var RecieverUser  = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == recieverPhoneNumber);
                        request.Reciever = RecieverUser.UserId;
                        shipment.Reciever = request.Reciever;

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
                                lineItems.LineTotal = resultValues.itemsA[i].LineTotal;
                                shipment.ShipmentItems.Add(lineItems);
                            }
                        }
                        else if (category == ShipmentCategory.MailAndParcel)
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

                        if (walletTransaction != null)
                        {
                            await _shipmentRepository.AddAsync(shipment);
                            PaymentCriteriaCommandResponse.paymentData.PaymentStatus = true;
                            PaymentCriteriaCommandResponse.paymentData.WaybillNumber = WaybillNumber;
                            PaymentCriteriaCommandResponse.paymentData.InvoiceNumber = invoiceCode;
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