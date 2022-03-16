using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment.GetPaymentById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPaymentByUserId
{
    public class GetPaymentByUserIdQuery : IRequest<PaymentViewModel>
    {
        public Guid UserId { get; set; }

        public GetPaymentByUserIdQuery(string userid)
        {
            Guid UserGuid = new Guid(userid);
            UserId = UserGuid;
        }
    }
}