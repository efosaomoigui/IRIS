using IRIS.BCK.Application.DTO;
using IRIS.BCK.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Application.Business.Shipments.Commands.CreateShipment
{
    public class CreateShipmentCommandResponse : BaseResponse
    {
        public CreateShipmentCommandResponse() : base()
        {

        }

        public ShipmentDto Shipmentdto { get; set; }
    }
}
