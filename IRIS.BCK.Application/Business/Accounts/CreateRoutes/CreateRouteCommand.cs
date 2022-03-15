using  IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateRoutes
{
    public class CreateRouteCommand : IRequest<CreateRouteCommandResponse>
    {
        public Guid RouteId { get; set; }

        public string RouteName { get; set; }

        public string Destination { get; set; }
        public string Departure { get; set; }
    }
}