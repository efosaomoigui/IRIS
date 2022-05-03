using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetTrips;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IFleetRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.ShipmentProcessing
{
    public class TripRepository : GenericRepository<Trips>, ITripRepository
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IFleetRepository _fleetRepository;
        private readonly UserManager<User> _userManager;
        public TripRepository(IRISDbContext dbContext, IRouteRepository routeRepository = null, UserManager<User> userManager = null, IFleetRepository fleetRepository = null) : base(dbContext)
        {
            _routeRepository = routeRepository;
            _userManager = userManager;
            _fleetRepository = fleetRepository;
        }

        public async Task<List<TripListViewModel>> GetTripManifestByRouteId() 
        {
            var trips = _dbContext.Trips.OrderBy(x => x.CreatedDate).ToList(); 
            List<TripListViewModel> allTrips = new List<TripListViewModel>();
             
            foreach (var trip in trips)
            {
                var singleGroupVm = new TripListViewModel();
                singleGroupVm.Id = trip.Id;
                singleGroupVm.TripReference = trip.TripReference;
                singleGroupVm.ManifestCode = trip.ManifestCode;
                singleGroupVm.RouteCode = trip.RouteCode;
                //singleGroupVm.UserId = trip.UserId;
                var user = await _userManager.FindByIdAsync(trip.Driver.ToString());
                //var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                var route = await _routeRepository.GetRouteById(trip.RouteCode.ToString());
                var fleet = await _fleetRepository.GetFleetById(trip.RouteFleetId.ToString());
                singleGroupVm.Departure = route.Departure;
                singleGroupVm.Destination = route.Destination;
                singleGroupVm.RouteName = route.RouteName;
                singleGroupVm.CreatedDate = route.CreatedDate;
                singleGroupVm.FleetChasis = fleet?.ChasisNumber;
                singleGroupVm.DriverName = user?.FirstName + " " + user?.LastName+ " (" + user?.PhoneNumber + ")" ;
                singleGroupVm.FleetFullDetails   = fleet?.FleetMake + " " + fleet?.FleetModel+ " (" + fleet?.ChasisNumber + ")" ;
                allTrips.Add(singleGroupVm);
            }
            return allTrips;
        }

        public async Task<List<TripListViewModel>> GetTripByReferenceCode(string code) 
        {
            var trips = _dbContext.Trips.Where(y => y.TripReference == code).OrderBy(x => x.CreatedDate).ToList();
            List<TripListViewModel> allTrips = new List<TripListViewModel>();

            foreach (var trip in trips)
            {
                var singleGroupVm = new TripListViewModel();
                singleGroupVm.Id = trip.Id;
                singleGroupVm.TripReference = trip.TripReference;
                singleGroupVm.ManifestCode = trip.ManifestCode;
                singleGroupVm.RouteCode = trip.RouteCode;
                //singleGroupVm.UserId = trip.UserId;
                var user = await _userManager.FindByIdAsync(trip.Driver.ToString());
                //var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                var route = await _routeRepository.GetRouteById(trip.RouteCode.ToString());
                var fleet = await _fleetRepository.GetFleetById(trip.RouteFleetId.ToString());
                singleGroupVm.Departure = route.Departure;
                singleGroupVm.Destination = route.Destination;
                singleGroupVm.RouteName = route.RouteName;
                singleGroupVm.CreatedDate = route.CreatedDate;
                singleGroupVm.FleetChasis = fleet?.ChasisNumber;
                singleGroupVm.DriverName = user?.FirstName + " " + user?.LastName + " (" + user?.PhoneNumber + ")";
                singleGroupVm.FleetFullDetails = fleet?.FleetMake + " " + fleet?.FleetModel + " (" + fleet?.ChasisNumber + ")";
                allTrips.Add(singleGroupVm);
            }
            return allTrips;
        }

        public async Task<List<TripListViewModel>> GetTripByReferenceCode2(string code) 
        {
            var trips = _dbContext.Trips.Where(y => y.TripReference == code).OrderBy(x => x.CreatedDate).ToList();
            List<TripListViewModel> allTrips = new List<TripListViewModel>();

            foreach (var trip in trips)
            {
                var singleGroupVm = new TripListViewModel();
                singleGroupVm.Id = trip.Id;
                singleGroupVm.TripReference = trip.TripReference;
                singleGroupVm.ManifestCode = trip.ManifestCode;
                singleGroupVm.RouteCode = trip.RouteCode;
                //singleGroupVm.UserId = trip.UserId;
                var user = await _userManager.FindByIdAsync(trip.Driver.ToString());
                //var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                var route = await _routeRepository.GetRouteById(trip.RouteCode.ToString());
                var fleet = await _fleetRepository.GetFleetById(trip.RouteFleetId.ToString());
                singleGroupVm.Departure = route.Departure;
                singleGroupVm.Destination = route.Destination;
                singleGroupVm.RouteName = route.RouteName;
                singleGroupVm.CreatedDate = route.CreatedDate;
                singleGroupVm.FleetChasis = fleet?.ChasisNumber;
                singleGroupVm.DriverName = user?.FirstName + " " + user?.LastName + " (" + user?.PhoneNumber + ")";
                singleGroupVm.FleetFullDetails = fleet?.FleetMake + " " + fleet?.FleetModel + " (" + fleet?.ChasisNumber + ")";
                allTrips.Add(singleGroupVm);
            }
            return allTrips;
        }

    }
}