using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.PaymentEntities
{
    public class Payment : Auditable
    {
        public Guid Id { get; set; }
        public string InvoiceCode { get; set; }

        public Guid ShipmentId { get; set; }
        public virtual Shipment Shipment { get; set; }
        public PaymentMethod PaymentMethod { get; set; } //wallet, Cash, Transfer
        public StatusEnum Status { get; set; } // paid/pending
    }
}