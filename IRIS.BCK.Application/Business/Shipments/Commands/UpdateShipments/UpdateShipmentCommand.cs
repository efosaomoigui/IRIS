using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateShipments
{
    public class UpdateShipmentCommand : IRequest<UpdateShipmentCommandResponse>
    {
        public int Id { get; set; }
        public string waybill { get; set; }
        public int FirstName { get; set; }
    }
}