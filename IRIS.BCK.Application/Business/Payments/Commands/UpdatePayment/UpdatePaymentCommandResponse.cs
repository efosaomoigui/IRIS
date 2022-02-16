using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.UpdatePayment
{
    public class UpdatePaymentCommandResponse : BaseResponse
    {
        public UpdatePaymentCommandResponse() : base()
        {
        }

        public PaymentDto Paymentdto { get; set; }
    }
}