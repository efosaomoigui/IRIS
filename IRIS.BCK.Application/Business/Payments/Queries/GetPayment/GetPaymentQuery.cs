using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment
{
    public class GetPaymentQuery : IRequest<List<PaymentListViewModel>>
    {
    }     
    
    public class GetUserPaymentQuery : IRequest<List<PaymentListViewModel>>
    {
        public string userId; 
        public GetUserPaymentQuery(string userId = null)
        {
            this.userId = userId;
        }
    }
}