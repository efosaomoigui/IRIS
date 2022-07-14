using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifest;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.ShipmentProcessing
{
    public class ManifestRepository : GenericRepository<Manifest>, IManifestRepository
    {
        private readonly IRouteRepository _routeRepository;
        public ManifestRepository(IRISDbContext dbContext, IRouteRepository routeRepository = null) : base(dbContext)
        {
            _routeRepository = routeRepository;
        }

        public async Task<List<Manifest>> GetManifestByManifestCode(string manifestcode)
        {
            return  _dbContext.Manifest.Where(e => e.ManifestCode == manifestcode).ToList();
        }
        public async Task<List<Manifest>> GetDistinctManifestByManifestCode(string manifestcode) 
        {
            List<Manifest> allTrips = new List<Manifest>();
            var result = _dbContext.Manifest.Where(e => e.ManifestCode == manifestcode)
                .Select(g => new Manifest
                {
                    ManifestCode = g.ManifestCode,
                    GroupWayBillCode = g.GroupWayBillCode,
                    RouteId = g.RouteId,
                    CreatedDate = new DateTime(g.CreatedDate.Year, g.CreatedDate.Month, g.CreatedDate.Day, g.CreatedDate.Hour, g.CreatedDate.Minute, g.CreatedDate.Second)
                }).Distinct().ToList();
            return result;
        }

        public async Task<Manifest> GetManifestByWayBill(string waybill)
        {
            return _dbContext.Manifest.FirstOrDefault(e => e.GroupWayBillCode.ToString() == waybill);
        }

        public async Task<List<ManifestListViewModel>> GetManifestGroupWaybillByRouteId()
        {
            var manifests = _dbContext.Manifest.OrderBy(x => x.CreatedDate).ToList()
            .Select(g => new {
                 g.ManifestCode,
                 g.CreatedDate.Month,
                 g.RouteId, 
                 Date = new DateTime(g.CreatedDate.Year, g.CreatedDate.Month, g.CreatedDate.Day, g.CreatedDate.Hour, g.CreatedDate.Minute, g.CreatedDate.Second)
             }).Distinct().ToList();
            List<ManifestListViewModel> allGroups = new List<ManifestListViewModel>();

            foreach (var manifest in manifests)
            {
                var singleGroupVm = new ManifestListViewModel();

                //singleGroupVm.Id = manifest.Id;
                //singleGroupVm.GroupWayBillCode = manifest.GroupWayBillCode;
                singleGroupVm.ManifestCode = manifest.ManifestCode;
                singleGroupVm.RouteId = manifest.RouteId;
                //singleGroupVm.UserId = manifest.UserId;
                //var user = await _userManager.FindByIdAsync(shipment.Customer.ToString());
                //var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                var route = await _routeRepository.GetRouteById(manifest.RouteId.ToString());
                singleGroupVm.Departure = route.Departure;
                singleGroupVm.Destination = route.Destination;
                singleGroupVm.CreatedDate = manifest.Date;
                //singleShipmentVm.CustomerName = user?.FirstName + " " + user?.LastName;
                allGroups.Add(singleGroupVm);
            }
            return allGroups;
        }

        public async Task<List<ManifestListViewModel>> GetManifestByRouteId(string routeid) 
        {
            var manifests = _dbContext.Manifest.OrderBy(x => x.CreatedDate).ToList();
            var manifestList = manifests.Where(e => e.RouteId.ToString() == routeid).ToList();

            List<ManifestListViewModel> allGroups = new List<ManifestListViewModel>();


            foreach (var manifest in manifestList)
            {
                var singleGroupVm = new ManifestListViewModel();

                singleGroupVm.Id = manifest.Id;
                singleGroupVm.GroupWayBillCode = manifest.GroupWayBillCode;
                singleGroupVm.ManifestCode = manifest.ManifestCode;
                singleGroupVm.RouteId = manifest.RouteId;
                singleGroupVm.UserId = manifest.UserId;
                //var user = await _userManager.FindByIdAsync(shipment.Customer.ToString());
                //var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                var route = await _routeRepository.GetRouteById(manifest.RouteId.ToString());
                singleGroupVm.Departure = route.Departure;
                singleGroupVm.Destination = route.Destination;
                singleGroupVm.CreatedDate = route.CreatedDate;
                //singleShipmentVm.CustomerName = user?.FirstName + " " + user?.LastName;
                allGroups.Add(singleGroupVm);
            }
            return allGroups;
        }

        public async Task<Manifest> GetManifestByManifestCodeSignle(string manifestcode)
        {
            return _dbContext.Manifest.FirstOrDefault(e => e.ManifestCode == manifestcode);
        }
    }
}