using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment.GetPaymentById;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPaymentByInvoiceCode
{
    public class GetPaymentByInvoiceCodeQuery : IRequest<ShipmentViewModel>
    {
        public string InvoiceCode { get; set; }

        public GetPaymentByInvoiceCodeQuery(string invoicecode)
        {
            InvoiceCode = invoicecode;
        }
    }
}