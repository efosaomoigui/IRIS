using IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePaymentLog;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.Payments
{
    public static class PaymentLogMapsCommand
    {
        public static PaymentLog CreatePaymentLogMapsCommand(CreatePaymentLogCommand request)
        {
            return new PaymentLog
            {
                PaymentMethod = request.PaymentMethod,
                Amount = request.Amount,
                PaymentId = request.PaymentId,
                TransactionCode = request.TransactionCode,
                UserId = request.UserId
            };
        }
    }
}