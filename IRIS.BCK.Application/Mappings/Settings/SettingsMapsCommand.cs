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
                ChassisNumber = request.ChassisNumber,
                OwnerId = request.OwnerId,
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
                AvailableAtTerminal = request.AvailableAtTerminal,
                AvailableOnline = request.AvailableOnline,
                CaptainFee = request.CaptainFee,
                DepartureCentreId = request.DepartureCentreId,
                DestinationCentreId = request.DestinationCentreId,
                DispatchFee = request.DispatchFee,
                IsSubRoute = request.IsSubRoute,
                LoaderFee = request.LoaderFee,
                MainRouteId = request.MainRouteId,
                RouteId = request.RouteId,
                RouteName = request.RouteName,
                RouteType = request.RouteType
            };
        }
    }
}