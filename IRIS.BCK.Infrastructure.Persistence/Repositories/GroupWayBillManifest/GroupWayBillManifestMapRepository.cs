using IRIS.BCK.Core.Application.Interfaces.IRepositories.IGroupWayBillManifest;
using IRIS.BCK.Core.Domain.Entities.GroupWayBillManifestMapEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.GroupWayBillManifest
{
    public class GroupWayBillManifestMapRepository : GenericRepository<GroupWayBillManifestMap>, IGroupWayBillManifestMapRepository
    {
        public GroupWayBillManifestMapRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }
    }
}