using IRIS.BCK.Core.Application.Interfaces.IRepositories.IMonitoringRepositories;
using IRIS.BCK.Core.Domain.Entities.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Monitoring
{
    public class TrackHistoryRepository : GenericRepository<TrackHistory>, ITrackHistoryRepository
    {
        public TrackHistoryRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }
    }
}