using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.PaymentEntities
{
    public class PaymentLog : Auditable
    {
        public Guid PaymentId { get; set; }
        public int Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string User { get; set; }
        public Guid TransactionId { get; set; }
    }
}