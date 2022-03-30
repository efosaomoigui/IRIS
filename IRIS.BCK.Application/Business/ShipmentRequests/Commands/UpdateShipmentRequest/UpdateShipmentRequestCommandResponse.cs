using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.ShipmentRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentRequests.Commands.UpdateShipmentRequest
{
    public class UpdateShipmentRequestCommandResponse : BaseResponse
    {
        public UpdateShipmentRequestCommandResponse() : base()
        {
        }

        public ShipmentRequestDto ShipmentRequestdto { get; set; }
    }
}