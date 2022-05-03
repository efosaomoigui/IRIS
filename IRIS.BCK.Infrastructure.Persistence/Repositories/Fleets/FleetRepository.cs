using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleets;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IFleetRepositories;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Fleets
{
    public class FleetRepository : GenericRepository<Fleet>, IFleetRepository
    {
        private readonly UserManager<User> _userManager;
        public FleetRepository(IRISDbContext dbContext, UserManager<User> userManager = null) : base(dbContext)
        {
            _userManager = userManager;
        }

        public Task<bool> CheckUniqueFleetId(string fleet)
        {
            throw new NotImplementedException();
        }

        public async Task<Fleet> GetFleetById(string fleetid)
        {
            return _dbContext.Fleet.FirstOrDefault(e => e.FleetId.ToString() == fleetid);
        }

        public async Task<Fleet> GetFleetByUserId(string userid)
        {
            return _dbContext.Fleet.FirstOrDefault(e => e.UserId.ToString() == userid);
        }

        public async Task<List<FleetListViewModel>> GetFleetWithOwner() 
        {
            var fleet = _dbContext.Fleet.OrderBy(x => x.CreatedDate).ToList();
            List<FleetListViewModel> allFleet = new List<FleetListViewModel>();

            foreach (var grp in fleet)
            {
                var singleFleet = new FleetListViewModel();

                singleFleet.FleetId = grp.FleetId;
                singleFleet.ChassisNumber = grp.ChasisNumber;
                singleFleet.Status = (grp.Status)? "Active": "InActive";
                var userOwner = await _userManager.FindByIdAsync(grp.OwnerId.ToString()); 
                //var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                //var route = await _routeRepository.GetRouteById(grp.RId.ToString());
                singleFleet.FleetType = grp.FleetType.ToString();
                singleFleet.FleetMake = grp.FleetMake;
                singleFleet.FleetModel = grp.FleetModel;
                singleFleet.CreatedDate = grp.CreatedDate;
                singleFleet.Capacity = grp.Capacity;
                singleFleet.OwnerName = userOwner.FirstName+" "+ userOwner.LastName;
                singleFleet.OwnerId = userOwner.UserId.ToString();
                //singleShipmentVm.CustomerName = user?.FirstName + " " + user?.LastName;
                allFleet.Add(singleFleet);
            }
            return allFleet;
        }
    }
}