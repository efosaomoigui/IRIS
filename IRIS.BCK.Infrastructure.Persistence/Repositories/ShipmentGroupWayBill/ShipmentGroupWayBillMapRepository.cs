using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentGroupWayBill;
using IRIS.BCK.Core.Domain.Entities.ShipmentGroupWayBillMapEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.ShipmentGroupWayBill
{
    public class ShipmentGroupWayBillMapRepository : GenericRepository<ShipmentGroupWayBillMap>, IShipmentGroupWayBillMapRepository
    {
        public ShipmentGroupWayBillMapRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }
    }
}