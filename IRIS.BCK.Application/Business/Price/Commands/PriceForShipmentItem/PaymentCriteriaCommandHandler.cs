﻿using AutoMapper;
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
        private IMediator _mediator;

        public PaymentCriteriaCommandHandler(IPriceEntRepository priceRepository, IWalletTransactionRepository walletTransactionRepository, IMapper mapper, IEmailService emailService, UserManager<User> userManager, INumberEntRepository numberEntRepository = null, IInvoiceRepository invoiceRepository = null, IShipmentRepository shipmentRepository = null, IMediator mediator = null)
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
                PaymentCriteriaCommandResponse = new PaymentCriteriaCommandResponse();
                PaymentCriteriaCommandResponse.PaymentStatus = false;

                //convert the jsonstring in values from UI
                var jsonString = request.Values.ToString();
                var resultValues = JsonConvert.DeserializeObject<Values>(jsonString);
                resultValues.shipmentCategory = (resultValues.shipmentCategory == "mailandparcel") ? "MailAndParcel" : resultValues.shipmentCategory;

                if (request.PaymentMethod == PaymentMethod.Wallet)
                {
                    request.CustomerPhoneNumber = checkPhone(resultValues.shipperPhoneNumber);
                    resultValues.shipperPhoneNumber = request.CustomerPhoneNumber;
                    var ShipperUser = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == resultValues.shipperPhoneNumber);
                    Guid newUserId = new Guid();

                    if (ShipperUser == null)
                    {
                        var userCommand = UserMapsCommand.CreateShipperMapsCommand(resultValues);
                        var newUser = await _mediator.Send(userCommand);
                        newUserId = newUser.Userdto.UserId;
                    }

                    request.UserId = (ShipperUser != null) ? ShipperUser.UserId : newUserId;

                    if (request.UserId.ToString() != null)
                    {

                        //get waybill and invoice code from request
                        request.InvoiceNumber = resultValues.invoiceNumber;
                        request.WaybillNumber = resultValues.waybillNumber;

                        var invoiceMap = PaymentMapsCommand.CreatePaymentValuesMapsCommand(request);
                        var invoiceExit = _invoiceRepository.GetAllAsync().Result.FirstOrDefault(x => x.InvoiceCode == request.InvoiceNumber);

                        if (invoiceExit == null)
                        {
                            await _invoiceRepository.AddAsync(invoiceMap);
                        }

                        //prepare shipment entries
                        var shipment = ShipmentMapsCommand.CreateShipmentValuesMapsCommand(request);
                        shipment.Waybill = request.WaybillNumber;

                        ShipmentCategory category;
                        Enum.TryParse(resultValues.shipmentCategory, out category);

                        var recieverPhoneNumber = checkPhone(resultValues.receiverPhoneNumber);
                        resultValues.receiverPhoneNumber = recieverPhoneNumber;

                        var RecieverUser = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == resultValues.receiverPhoneNumber);
                        if (RecieverUser == null)
                        {
                            var receiverCommand = UserMapsCommand.CreateReceiverMapsCommand(resultValues);
                            var newReceiver = await _mediator.Send(receiverCommand);

                            //request.Reciever = RecieverUser.UserId;
                            shipment.Reciever = newReceiver.Userdto.UserId;
                        }

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

                        //check existing shipment
                        var shipmentExit = _shipmentRepository.GetAllAsync().Result.FirstOrDefault(x => x.Waybill == request.WaybillNumber);

                        //do shipment insert
                        if (shipmentExit == null) 
                        {
                            shipment.CustomerName = resultValues.shipperFullName;
                            shipment.RecieverName = resultValues.receiverFullName;
                            var shipmentval = await _shipmentRepository.AddAsync(shipment);
                        }

                        //do wallet payment
                        var walletTransaction = WalletTransactionsMapsCommand.CreateWalletTransactionsCriteriaMapsCommand(request);
                        walletTransaction = _walletTransactionRepository.WalletDebit(walletTransaction).Result;

                        if (walletTransaction == null)
                        {
                            PaymentCriteriaCommandResponse.PaymentStatus = false;
                        }
                        else
                        {
                            PaymentCriteriaCommandResponse.PaymentMethod = PaymentMethod.Wallet;
                            PaymentCriteriaCommandResponse.PaymentStatus = true;

                            //update invoice
                            var invoiceExitCheckt = _invoiceRepository.GetAllAsync().Result.FirstOrDefault(x => x.InvoiceCode == request.InvoiceNumber);
                            invoiceExitCheckt.PaymentMethod = PaymentMethod.Wallet;
                            invoiceExitCheckt.Status = StatusEnum.Paid;
                            await _invoiceRepository.UpdateAsync(invoiceExitCheckt);
                        }
                    }
                }
                else if (request.PaymentMethod == PaymentMethod.PostPaid)
                {
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