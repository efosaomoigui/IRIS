using GIGLS.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateRoute
{
    public class UpdateRouteCommand : IRequest<UpdateRouteCommandResponse>
    {
        public int RouteId { get; set; }

        public string RouteName { get; set; }

        public string Destination { get; set; }
        public string Departure { get; set; }
        public bool IsSubRoute { get; set; }

        public decimal DispatchFee { get; set; }

        public decimal LoaderFee { get; set; }

        public decimal CaptainFee { get; set; }
        public int? MainRouteId { get; set; }

        public bool AvailableAtTerminal { get; set; }

        public bool AvailableOnline { get; set; }
        public RouteType RouteType { get; set; }
    }
}