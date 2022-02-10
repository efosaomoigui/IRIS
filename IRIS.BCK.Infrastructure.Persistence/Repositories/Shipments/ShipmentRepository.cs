using IRIS.BCK.Application.DTO;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
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

        public Task DeleteAsync(Shipment shipment)
        {
            return DeleteAsync(shipment);
        }

        public async Task<Shipment> Get(int id)
        {
            return await Get(x => x.Id == id);
        }
    }
}