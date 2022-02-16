using IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePayment;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.Payment
{
    public static class PaymentMapsCommand
    {
        public static Payments CreatePaymentMapsCommand(CreatePaymentCommand request)
        {
            return new Payments
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