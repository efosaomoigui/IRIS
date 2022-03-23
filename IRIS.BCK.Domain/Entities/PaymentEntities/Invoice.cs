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
    public class Invoice : Auditable
    {
        public Guid Id { get; set; }
        public double Amount { get; set; } 
        public string InvoiceCode { get; set; }
        public Guid UserId { get; set; }
        public string WaybilNumber { get; set; } 
        public PaymentMethod PaymentMethod { get; set; } 
        public StatusEnum Status { get; set; }
    }
}