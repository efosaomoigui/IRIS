﻿using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Price;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem
{
    public class PaymentCriteriaCommandResponse : BaseResponse
    {
        public PaymentCriteriaCommandResponse() : base() 
        { 
        }

        //public PaymentCriteriaCommand paymentData { get; set; }  

        public PaymentMethod PaymentMethod { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public double Amount { get; set; }
        public Guid UserId { get; set; }
        public TransactionType WalletTransactionType { get; set; }
        public Guid Reciever { get; set; }
        public string InvoiceNumber { get; set; }
        public string WaybillNumber { get; set; }
        public ShipmentCategory ShimentCategory { get; set; }
        public string RouteId { get; set; }
        public bool PaymentStatus { get; set; }
        public string Description { get; set; }
        public object Values { get; set; }
    }
}