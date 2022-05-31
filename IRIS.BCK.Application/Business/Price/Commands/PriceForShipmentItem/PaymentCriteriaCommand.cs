using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem
{
    public class PaymentCriteriaCommand : IRequest<PaymentCriteriaCommandResponse>
    {
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
        public bool IsShipmentRegistered { get; set; }
        public string Description { get; set; }
        public object Values { get; set; }
    }

    public class UpdatePaymentPendingCommand : IRequest<PaymentCriteriaCommandResponse>  
    {
        public PaymentMethod PaymentMethod { get; set; }
        public double Amount { get; set; }
        public Guid UserId { get; set; }
        public string InvoiceNumber { get; set; }
        public string WaybillNumber { get; set; }
        public ShipmentCategory ShipmentCategory { get; set; } 
        public bool PaymentStatus { get; set; }
    }

    public class RegisterShipmentCommand : IRequest<PaymentCriteriaCommandResponse>   
    {
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
        public bool IsShipmentRegistered { get; set; } 
        public string Description { get; set; }
        public object Values { get; set; }
    }
}