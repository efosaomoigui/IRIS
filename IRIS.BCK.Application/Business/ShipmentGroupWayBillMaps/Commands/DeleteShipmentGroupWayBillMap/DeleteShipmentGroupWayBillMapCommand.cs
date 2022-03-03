using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.DeleteShipmentGroupWayBillMap
{
    public class DeleteShipmentGroupWayBillMapCommand : IRequest<DeleteShipmentGroupWayBillMapCommandResponse>
    {
        public Guid id { get; set; }
    }
}