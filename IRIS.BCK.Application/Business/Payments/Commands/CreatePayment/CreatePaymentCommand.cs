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
        public Guid Id { get; set; }
        public string InvoiceCode { get; set; }
        public Guid ShipmentId { get; set; }
        public Guid UserId { get; set; }
        public double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; } //wallet, Cash, Transfer
        public StatusEnum Status { get; set; } // paid/pending
    }
}