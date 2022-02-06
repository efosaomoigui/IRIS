﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetRoutes
{
    public class GetRouteQuery : IRequest<List<RouteViewModel>>
    {
    }
}