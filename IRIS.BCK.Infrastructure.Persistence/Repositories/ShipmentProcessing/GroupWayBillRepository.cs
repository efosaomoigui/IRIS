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
        public GroupWayBillRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }
    }
}