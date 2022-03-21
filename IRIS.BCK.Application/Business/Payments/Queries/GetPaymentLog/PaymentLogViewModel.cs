using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPaymentLog
{
    public class PaymentLogViewModel
    {
        public Guid PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public Guid UserId { get; set; }
        public string TransactionCode { get; set; }
    }
}