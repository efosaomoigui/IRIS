using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistory;
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
        Task<TrackHistory> GetTrackHistoryById(string trackhistoryid);

        Task<TrackHistory> GetTrackHistoryByTripReference(string tripreference);

        Task<List<TrackHistoryListViewModel>> GetTrackHistoryWithStatusAsync();
        Task<List<TrackHistoryListViewModel>> GetUserTrackHistoryWithStatusAsync(string userId); 

        Task<List<TrackHistoryListViewModel>> GetTrackHistoryWithStatusAsyncSearch(string code);
        Task<List<TrackHistoryListViewModel>> GetUserTrackHistoryWithStatusAsyncSearch(string code, string userId);



    }
}