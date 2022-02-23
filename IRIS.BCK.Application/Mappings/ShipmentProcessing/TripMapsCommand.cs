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
                Status = request.Status,
                StartTime = request.StartTime,
                RouteCode = request.RouteCode,
                Miscelleneous = request.Miscelleneous,
                manifest = request.manifest,
                FuelUsed = request.FuelUsed,
                FuelCosts = request.FuelCosts,
                //Dispatcher = request.Dispatcher,
                // Driver = request.Driver,
                DriverDispatchFee = request.DriverDispatchFee,
                Fleet = request.Fleet,
            };
        }
    }
}