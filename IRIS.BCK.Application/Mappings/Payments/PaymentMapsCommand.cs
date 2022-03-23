using IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePayment;
using IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.Payments
{
    public static class PaymentMapsCommand
    {
        public static Invoice CreatePaymentMapsCommand(CreatePaymentCommand request)
        {
            return new Invoice
            {
                InvoiceCode = request.InvoiceCode,
                UserId = (Guid)request.UserId,
                WaybilNumber = request.WaybillNumber,
                PaymentMethod = request.PaymentMethod, 
                Amount = request.Amount,
                Status = request.Status
            };
        }       
        
        public static Invoice CreatePaymentValuesMapsCommand(PaymentCriteriaCommand request)
        {
            return new Invoice
            {
                InvoiceCode = request.InvoiceNumber,
                UserId = (Guid)request.UserId,
                WaybilNumber = request.WaybillNumber,
                PaymentMethod = request.PaymentMethod, 
                Amount = request.Amount,
            };
        }
    }
}