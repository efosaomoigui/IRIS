using IRIS.BCK.Application.DTO;
using IRIS.BCK.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteShipment
{
    public class DeleteShipmentCommandResponse : BaseResponse
    {
        public DeleteShipmentCommandResponse() : base()
        {
        }

        public ShipmentDto Shipmentdto { get; set; }
    }
}