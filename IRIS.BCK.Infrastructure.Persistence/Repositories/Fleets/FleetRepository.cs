using IRIS.BCK.Core.Application.Interfaces.IRepositories.IFleetRepositories;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Fleets
{
    public class FleetRepository : GenericRepository<Fleet>, IFleetRepository
    {
        public FleetRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> CheckUniqueFleetId(string fleet)
        {
            throw new NotImplementedException();
        }
    }
}