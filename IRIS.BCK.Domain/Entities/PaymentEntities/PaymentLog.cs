using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.PaymentEntities
{
    public class PaymentLog : Auditable
    {
        [Key]
        public Guid PaymentId { get; set; }

        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
        public Guid UserId { get; set; }
        public string TransactionCode { get; set; }
    }
}