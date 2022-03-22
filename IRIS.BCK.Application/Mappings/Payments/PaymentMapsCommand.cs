using IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePayment;
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
                Status = request.Status,
                PaymentMethod = request.PaymentMethod,
                Amount = request.Amount,
                ShipmentId = request.ShipmentId
            };
        }
    }
}