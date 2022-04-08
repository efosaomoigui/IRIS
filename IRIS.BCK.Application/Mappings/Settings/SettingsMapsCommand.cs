using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateFleets;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateRoutes;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;

namespace IRIS.BCK.Core.Application.Mappings.Settings
{
    public static class SettingsMapsCommand
    {
        public static Fleet CreateFleetMapsCommand(CreateFleetCommand request)
        {
            return new Fleet
            {
                Capacity = request.Capacity,
                ChasisNumber = request.ChassisNumber,
                UserId = request.OwnerId,
                Description = request.Description,
                EngineNumber = request.EngineNumber,
                FleetId = request.FleetId,
                FleetMake = request.FleetMake,
                FleetModel = request.FleetModel,
                FleetType = request.FleetType,
                RegistrationNumber = request.RegistrationNumber,
                Status = request.Status
            };
        }

        public static Route CreateRouteMapsCommand(CreateRouteCommand request)
        {
            return new Route
            {
                Departure = request.Departure,
                Destination = request.Destination,
                RouteId = request.RouteId,
                RouteName = request.RouteName,
            };
        }
    }
}