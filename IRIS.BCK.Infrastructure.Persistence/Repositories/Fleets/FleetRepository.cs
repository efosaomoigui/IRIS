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

        public async Task<Fleet> GetFleetById(string fleetid)
        {
            return _dbContext.Fleet.FirstOrDefault(e => e.FleetId.ToString() == fleetid);
        }

        public async Task<Fleet> GetFleetByUserId(string userid)
        {
            return _dbContext.Fleet.FirstOrDefault(e => e.UserId.ToString() == userid);
        }
    }
}