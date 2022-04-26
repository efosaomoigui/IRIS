using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifest;
using MediatR;
using System;
using System.Collections.Generic;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetGroupWayBill
{
    public class GetManifestByRouteIdQuery : IRequest<List<ManifestListViewModel>>
    {
        public Guid RouteId { get; set; }

        public GetManifestByRouteIdQuery(string routeid) 
        {
            RouteId = new Guid(routeid); 
        }
    }
}