using AutoMapper;
using IRIS.BCK.Application.DTO;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Shipments
{
    public class ShipmentRepository : GenericRepository<Shipment>, IShipmentRepository
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        public ShipmentRepository(IRISDbContext dbContext, IRouteRepository routeRepository = null, IMapper mapper = null) : base(dbContext)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<bool> CheckUniqueWaybillNumber(string waybill)
        {
            return true;
        }

        public async Task<bool> CheckUniqueWaybillNumberFiftyCharacterslong(string waybill)
        {
            return true;
        }

        public async Task<List<Shipment>> GetShipmentAndItemsAndRoute()
        {
            var lsShipments = await _dbContext.Shipment.Include(s => s.ShipmentItems).Include(x => x.Route).ToListAsync();
            return lsShipments;
        }

        public async Task<List<Shipment>> GetUserShipmentAndItemsAndRoute(string userId)
        {
            var lsShipments = await _dbContext.Shipment.Where(x => x.Customer == new Guid(userId)).Include(s => s.ShipmentItems).Include(x => x.Route).ToListAsync();
            return lsShipments;
        }

        public async Task<List<DashboardShipmentListViewModel>> GetMonthlyShipmentByCreatedDate()
        {
            var lsShipments = await _dbContext.Shipment.OrderByDescending(g => g.CreatedDate)
                .GroupBy(x => new { x.CreatedDate.Month })
                .Select(g => new DashboardShipmentListViewModel
                {
                    Month = g.Key.Month.ToString(),
                    MonthData = g.Sum(y => y.GrandTotal)
                }).ToListAsync();

            return lsShipments;
        }

        public async Task<List<DashboardShipmentListViewModel>> GetUserMonthlyShipmentByCreatedDate(string userId)
        {
            var lsShipments = await _dbContext.Shipment.Where(s => s.Customer == new Guid(userId)).GroupBy(x => new { x.CreatedDate.Month }).OrderBy(g => g.Key.Month)
                .Select(g => new DashboardShipmentListViewModel
                {
                    Month = g.Key.Month.ToString(),
                    MonthData = g.Sum(y => y.GrandTotal) 
                }).ToListAsync();

            return lsShipments;
        }

        public async Task<Shipment> GetShipmentById(string shipmentid)
        {
            return _dbContext.Shipment.FirstOrDefault(e => e.ShipmentId.ToString() == shipmentid);
        }

        public async Task<List<Guid>> GetUnprocessedShipment()
        {
            return _dbContext.Shipment.Where(e => e.ShipmentProcessingStatus == ShipmentProcessingStatus.Created).Select(e => e.ShipmentRouteId).Distinct().ToList();
        }

        public async Task<List<ShipmentRouteViewModel>> GetShipmentByRouteId(string routeid)
        {
            //return _dbContext.Shipment.(e => e.ShipmentRouteId.ToString() == routeid);
            var shipments = _dbContext.Shipment.ToList();
            var shipmentLst = shipments.Where(e => e.ShipmentRouteId.ToString() == routeid).ToList();
            List<ShipmentRouteViewModel> allShiments = new List<ShipmentRouteViewModel>();

            foreach (var shipment in shipmentLst)
            {
                var singleShipmentVm = new ShipmentRouteViewModel();

                singleShipmentVm.ShipmentId = shipment.ShipmentId;
                singleShipmentVm.Waybill = shipment.Waybill;
                singleShipmentVm.Customer = shipment.Customer;
                singleShipmentVm.CustomerAddress = shipment.CustomerAddress;
                singleShipmentVm.Reciever = shipment.Reciever;
                singleShipmentVm.RecieverAddress = shipment.RecieverAddress;
                //var user = await _userManager.FindByIdAsync(shipment.Customer.ToString());
                //var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                var route = await _routeRepository.GetRouteById(shipment.ShipmentRouteId.ToString());
                singleShipmentVm.Departure = route.Departure;
                singleShipmentVm.Destination = route.Destination;
                singleShipmentVm.PickupOptions = shipment.PickupOptions.ToString();
                //singleShipmentVm.CustomerName = user?.FirstName + " " + user?.LastName;
                singleShipmentVm.RecieverName = shipment.RecieverName;
                singleShipmentVm.GrandTotal = shipment.GrandTotal;
                singleShipmentVm.GrandTotal = shipment.GrandTotal;
                singleShipmentVm.CreatedDate = shipment.CreatedDate;
                //singleShipmentVm.RecieverPhoneNumber = user2.PhoneNumber;
                //singleShipmentVm.CustomerPhoneNumber = user.PhoneNumber;
                singleShipmentVm.ShipmentCategory = shipment.ShipmentCategory.ToString();

                allShiments.Add(singleShipmentVm);
            }

            return allShiments; // shipments.Where(e => e.ShipmentRouteId.ToString() == routeid).ToList();
        }

        public async Task<Shipment> GetShipmentByWayBillNumber(string waybillnumber)
        {
            var lsShipments = await _dbContext.Shipment.Include(s => s.ShipmentItems).Include(x => x.Route).FirstOrDefaultAsync(e => e.Waybill == waybillnumber);
            return lsShipments;
        }

        public async Task<Shipment> GetShipmentByWayBill(string waybillnumber)
        {
            var lsShipments = await _dbContext.Shipment.FirstOrDefaultAsync(e => e.Waybill == waybillnumber);
            return lsShipments;
        }

        public async Task<List<Shipment>> GetShipmentByWayBillUsingListWaybills(List<string> waybillnumbers)
        {
            var lsShipments = _dbContext.Shipment.Where(e => waybillnumbers.Contains(e.Waybill)).ToList();
            return lsShipments;
        }
    }
}