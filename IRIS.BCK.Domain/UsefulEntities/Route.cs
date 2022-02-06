﻿using GIGLS.Core.Enums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.Core.Domain.Route
{
    public class Route : Auditable
    {
        public int RouteId { get; set; }

        public string RouteName { get; set; }

        public int DepartureCentreId { get; set; }

        // public ServiceCentre DepartureCenter { get; set; }

        public int DestinationCentreId { get; set; }

        //public ServiceCentre DestinationCenter { get; set; }

        public bool IsSubRoute { get; set; }

        public decimal DispatchFee { get; set; }

        public decimal LoaderFee { get; set; }

        public decimal CaptainFee { get; set; }

        //parentRoute
        public int? MainRouteId { get; set; }

        public bool AvailableAtTerminal { get; set; }

        public bool AvailableOnline { get; set; }

        public RouteType RouteType { get; set; }
    }
}