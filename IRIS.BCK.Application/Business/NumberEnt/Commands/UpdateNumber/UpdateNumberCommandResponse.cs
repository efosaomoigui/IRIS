using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.UpdateNumber
{
    public class UpdateNumberCommandResponse : BaseResponse
    {
        public UpdateNumberCommandResponse() : base()
        {
        }

        public PaymentDto Paymentdto { get; set; }
    }
}