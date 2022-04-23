﻿using MediatR;
using System;
using System.Collections.Generic;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetGroupWayBill
{
    public class GetManifestGroupwaybillByRouteIdQuery : IRequest<List<GroupWayBillListViewModel>>
    {
        public Guid RouteId { get; set; }

        public GetManifestGroupwaybillByRouteIdQuery(string routeid) 
        {
            RouteId = new Guid(routeid);
        }
    }
}