using IRIS.BCK.Application.DTO;
using IRIS.BCK.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateShipments
{
    public class UpdateShipmentCommandResponse : BaseResponse
    {
        public UpdateShipmentCommandResponse() : base()
        {
        }

        public ShipmentDto Shipmentdto { get; set; }
    }
}