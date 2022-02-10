using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteShipment
{
    public class DeleteShipmentCommand : IRequest<DeleteShipmentCommandResponse>
    {
        public int Id { get; set; }
        public string waybill { get; set; }
        public int FirstName { get; set; }
    }
}