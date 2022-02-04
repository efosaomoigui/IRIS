using IRIS.BCK.Core.Application.Business.Routes.Queries.GetRoutes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Routes.Queries.GetOneRoute
{
    public class GetRouteByIdQuery : IRequest<List<RouteViewModel>>
    {
    }
}