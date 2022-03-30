using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.ShipmentRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentRequests.Commands.CreateShipmentRequest
{
    public class CreateShipmentRequestCommandResponse : BaseResponse
    {
        public CreateShipmentRequestCommandResponse() : base()
        {
        }

        public ShipmentRequestDto ShipmentRequestdto { get; set; }
    }
}