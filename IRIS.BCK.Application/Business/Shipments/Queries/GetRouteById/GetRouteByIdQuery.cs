using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetRoutes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetOneRoute
{
    public class GetRouteByIdQuery : IRequest<List<RouteViewModel>>
    {
    }
}