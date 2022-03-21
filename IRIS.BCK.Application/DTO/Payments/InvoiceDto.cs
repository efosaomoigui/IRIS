using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.DTO.Payments
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public string InvoiceCode { get; set; }

        public Guid ShipmentId { get; set; }
        public virtual Shipment Shipment { get; set; }
        public Guid UserId { get; set; }
        public string WalletNumber { get; set; }
        public PaymentMethod PaymentMethod { get; set; } //wallet, Cash, Transfer
        public StatusEnum Status { get; set; } // paid/pending
    }
}