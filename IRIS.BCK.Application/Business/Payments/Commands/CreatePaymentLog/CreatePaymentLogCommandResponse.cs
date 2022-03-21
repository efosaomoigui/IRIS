using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePaymentLog
{
    public class CreatePaymentLogCommandResponse : BaseResponse
    {
        public CreatePaymentLogCommandResponse() : base()
        {
        }

        public PaymentLogDto PaymentLogdto { get; set; }
    }
}