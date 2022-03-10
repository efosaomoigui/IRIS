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
        public static Payment CreatePaymentMapsCommand(CreatePaymentCommand request)
        {
            return new Payment
            {
                InvoiceCode = request.InvoiceCode,
                Status = request.Status,
                PaymentMethod = request.PaymentMethod,
                Shipment = request.Shipment,
                ShipmentId = request.ShipmentId
            };
        }
    }
}