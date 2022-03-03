using GIGLS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetRoutes
{
    public class RouteViewModel
    {
        public int RouteId { get; set; }

        public string RouteName { get; set; }

        public string Departure { get; set; }

        public string Destination { get; set; }
    }
}