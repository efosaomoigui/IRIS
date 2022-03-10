using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById
{
    public class GetShipmentByIdQuery : IRequest<ShipmentViewModel>
    {
        public Guid ShipmentId { get; set; }

        public GetShipmentByIdQuery(string shipmentid)
        {
            Guid ShipmentGuid = new Guid(shipmentid);
            ShipmentId = ShipmentGuid;
        }
    }
}