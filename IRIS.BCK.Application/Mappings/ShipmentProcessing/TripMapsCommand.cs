using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateTrips;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
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
        public static List<Trips> CreateTripMapsCommand(CreateTripCommand request)
        {
            var listOfTrip = new List<Trips>();

            foreach (var item in request.ManifestList)
            {
                if (item.ManifestCode != "")
                {
                    var grp = new Trips
                    {
                        TripReference = request.TripReference,
                        RouteCode = request.RouteCode,
                        Dispatcher = request.Dispatcher,
                        Driver = new Guid(request.Driver),
                        RouteFleetId = new Guid(request.Fleet),
                        ManifestCode = item.ManifestCode,
                        ManifestId = request.ManifestId
                    };

                    listOfTrip.Add(grp);
                }
            }
            return listOfTrip;
        }
    }
}