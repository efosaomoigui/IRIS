using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetGroupWayBill;
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
    public class GroupWayBillRepository : GenericRepository<GroupWayBill>, IGroupWayBillRepository
    {
        private readonly IRouteRepository _routeRepository;
        public GroupWayBillRepository(IRISDbContext dbContext, IRouteRepository routeRepository = null) : base(dbContext)
        {
            _routeRepository = routeRepository;
        }

        public async Task<List<GroupWayBillListViewModel>> GetGroupWaybillByRouteId()
        {
            var groupShipments = _dbContext.GroupWayBill.OrderBy(x => x.CreatedDate).ToList(); 
            List<GroupWayBillListViewModel> allGroups = new List<GroupWayBillListViewModel>();

            foreach (var grp in groupShipments) 
            {
                var singleGroupVm = new GroupWayBillListViewModel();

                singleGroupVm.Id = grp.Id;
                singleGroupVm.Waybill = grp.Waybill;
                singleGroupVm.GroupCode = grp.GroupCode;
                //var user = await _userManager.FindByIdAsync(shipment.Customer.ToString());
                //var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                var route = await _routeRepository.GetRouteById(grp.RId.ToString());
                singleGroupVm.Departure = route.Departure;
                singleGroupVm.Destination = route.Destination;
                singleGroupVm.CreatedDate = route.CreatedDate;
                //singleShipmentVm.CustomerName = user?.FirstName + " " + user?.LastName;
                allGroups.Add(singleGroupVm);
            }
            return allGroups;
        }

        public async Task<List<GroupWayBillListViewModel>> GetManifestGroupwaybillByRouteId(string routeid) 
        {
            var groupShipments = _dbContext.GroupWayBill.OrderBy(x => x.CreatedDate).ToList();
            var groupShipmentList = groupShipments.Where(e => e.RId.ToString() == routeid).ToList();

            List<GroupWayBillListViewModel> allGroups = new List<GroupWayBillListViewModel>();

            foreach (var grp in groupShipmentList)
            {
                var singleGroupVm = new GroupWayBillListViewModel();

                singleGroupVm.Id = grp.Id;
                singleGroupVm.Waybill = grp.Waybill;
                singleGroupVm.GroupCode = grp.GroupCode;
                //var user = await _userManager.FindByIdAsync(shipment.Customer.ToString());
                //var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                var route = await _routeRepository.GetRouteById(grp.RId.ToString());
                singleGroupVm.Departure = route.Departure;
                singleGroupVm.Destination = route.Destination;
                singleGroupVm.CreatedDate = route.CreatedDate;
                singleGroupVm.RouteId = grp.RId;
                //singleShipmentVm.CustomerName = user?.FirstName + " " + user?.LastName;
                allGroups.Add(singleGroupVm);
            }
            return allGroups;
        }
    }
}