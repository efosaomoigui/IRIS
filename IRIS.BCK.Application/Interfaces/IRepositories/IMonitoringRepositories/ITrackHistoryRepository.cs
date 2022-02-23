using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.IMonitoringRepositories
{
    public interface ITrackHistoryRepository : IGenericRepository<TrackHistory>
    {
    }
}