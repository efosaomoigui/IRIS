using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById
{
    public class GetShipmentByRouteIdQuery : IRequest<List<ShipmentRouteViewModel>>
    {
        public Guid RouteId { get; set; } 

        public GetShipmentByRouteIdQuery(string routeid)
        {
            RouteId = new Guid(routeid);
        }
    }
}