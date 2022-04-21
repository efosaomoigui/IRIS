using IRIS.BCK.Application.DTO;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
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
        public ShipmentRepository(IRISDbContext dbContext) : base(dbContext)
        {
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

        public async Task<Shipment> GetShipmentById(string shipmentid)
        {
            return _dbContext.Shipment.FirstOrDefault(e => e.ShipmentId.ToString() == shipmentid);
        }
         
        public async Task<List<Shipment>> GetShipmentByRouteId(string routeid) 
        {
            //return _dbContext.Shipment.(e => e.ShipmentRouteId.ToString() == routeid);
            var shipments = _dbContext.Shipment;
            return shipments.Where(e => e.ShipmentRouteId.ToString() == routeid).ToList();
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
    }
}