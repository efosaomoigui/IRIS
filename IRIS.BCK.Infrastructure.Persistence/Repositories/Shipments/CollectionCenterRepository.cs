using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentRepositories;
using IRIS.BCK.Core.Domain.Entities.ShipmentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Shipments
{
    public class CollectionCenterRepository : GenericRepository<CollectionCenter>, ICollectionCenterRepository
    {
        public CollectionCenterRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }
    }
}