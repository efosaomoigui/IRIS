using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentRequestRepositories;
using IRIS.BCK.Core.Domain.Entities.ShipmentRequestEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.ShipmentRequests
{
    public class ShipmentRequestRepository : GenericRepository<ShipmentRequest>, IShipmentRequestRepository
    {
        public ShipmentRequestRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }
    }
}