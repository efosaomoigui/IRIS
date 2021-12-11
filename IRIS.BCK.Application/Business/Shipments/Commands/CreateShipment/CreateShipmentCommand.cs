using IRIS.BCK.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment
{
    public class CreateShipmentCommand : IRequest<CreateShipmentCommandResponse>
    {
        public int Id { get; set; }
        public string waybill { get; set; }
    }
}
