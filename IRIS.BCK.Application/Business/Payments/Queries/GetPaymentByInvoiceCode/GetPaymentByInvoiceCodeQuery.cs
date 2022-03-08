using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment.GetPaymentById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPaymentByInvoiceCode
{
    public class GetPaymentByInvoiceCodeQuery : IRequest<PaymentViewModel>
    {
        public string InvoiceCode { get; set; }

        public GetPaymentByInvoiceCodeQuery(string invoicecode)
        {
            string PaymentStr = new string(invoicecode);
            InvoiceCode = PaymentStr;
        }
    }
}