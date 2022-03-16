using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment.GetPaymentById
{
    public class PaymentViewModel
    {
        public Guid Id { get; set; }
        public string InvoiceCode { get; set; }

        public Guid UserId { get; set; }

        public Guid ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool Status { get; set; }
    }
}