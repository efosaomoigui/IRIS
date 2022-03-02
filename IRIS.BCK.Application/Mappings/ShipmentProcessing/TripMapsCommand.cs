using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateTrips;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.ShipmentProcessing
{
    public static class TripMapsCommand
    {
        public static Trips CreateTripMapsCommand(CreateTripCommand request)
        {
            return new Trips
            {
                TripReference = request.TripReference,
                StartTime = request.StartTime,
                RouteCode = request.RouteCode,
                DriverDispatchFee = request.DriverDispatchFee,
            };
        }
    }
}