﻿using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetRoutes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetOneRoute
{
    public class GetRouteByIdQuery : IRequest<RouteViewModel>
    {
        public Guid RouteId { get; set; }

        public GetRouteByIdQuery(string routeid)
        {
            Guid RouteGuid = new Guid(routeid);
            RouteId = RouteGuid;
        }
    }
}