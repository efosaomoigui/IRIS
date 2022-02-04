using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Routes.Commands.CreateRoutes
{
    public class CreateRouteCommand : IRequest<CreateRouteCommandResponse>
    {
        public int RouteId { get; set; }

        public string RouteName { get; set; }

        public int DepartureCentreId { get; set; }
        public int DestinationCentreId { get; set; }
        public bool IsSubRoute { get; set; }

        public decimal DispatchFee { get; set; }

        public decimal LoaderFee { get; set; }

        public decimal CaptainFee { get; set; }
        public int? MainRouteId { get; set; }

        public bool AvailableAtTerminal { get; set; }

        public bool AvailableOnline { get; set; }
    }
}