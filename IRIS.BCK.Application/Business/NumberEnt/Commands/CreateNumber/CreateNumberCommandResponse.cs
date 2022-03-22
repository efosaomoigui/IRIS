using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.NumberEnt;
using IRIS.BCK.Core.Application.DTO.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.CreateNumberEnt
{
    public class CreateNumberCommandResponse : BaseResponse
    {
        public CreateNumberCommandResponse() : base()
        {
        }

        public NumberEntDto NumberEntDto { get; set; }
    }
}