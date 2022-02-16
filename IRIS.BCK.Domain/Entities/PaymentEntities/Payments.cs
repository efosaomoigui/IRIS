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
    public class Payments : Auditable
    {
        //public GUID Id { get; set; }
        public string InvoiceCode { get; set; }

        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        public PaymentMethod PaymentMethod { get; set; } //wallet, Cash, Transfer
        public bool Status { get; set; } // paid/pending
    }
}