using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommand : IRequest<CreatePaymentCommandResponse>
    {
        public string InvoiceCode { get; set; }
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool Status { get; set; }
    }
}