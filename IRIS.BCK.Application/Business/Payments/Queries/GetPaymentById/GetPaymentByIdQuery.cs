using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment.GetPaymentById
{
    public class GetPaymentByIdQuery : IRequest<PaymentViewModel>
    {
        public Guid Id { get; set; }

        public GetPaymentByIdQuery(string id)
        {
            Guid PaymentGuid = new Guid(id);
            Id = PaymentGuid;
        }
    }
}