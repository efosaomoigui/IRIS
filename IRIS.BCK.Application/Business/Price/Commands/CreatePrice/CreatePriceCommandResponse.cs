using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.CreatePrice
{
    public class CreatePriceCommandResponse : BaseResponse
    {
        public CreatePriceCommandResponse() : base()
        {
        }

        public PriceDto pricedto { get; set; }
    }
}