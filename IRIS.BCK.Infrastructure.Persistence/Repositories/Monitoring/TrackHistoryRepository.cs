using AutoMapper;
using IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistory;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetTrips;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IMonitoringRepositories;
using IRIS.BCK.Core.Domain.Entities.Monitoring;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Monitoring
{
    public class TrackHistoryRepository : GenericRepository<TrackHistory>, ITrackHistoryRepository
    {
        private readonly IMapper _mapper;
        public TrackHistoryRepository(IRISDbContext dbContext, IMapper mapper = null) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<TrackHistory> GetTrackHistoryById(string trackhistoryid)
        {
            return _dbContext.TrackHistory.FirstOrDefault(e => e.Id.ToString() == trackhistoryid);
        }

        public async Task<TrackHistory> GetTrackHistoryByTripReference(string tripreference)
        {
            return _dbContext.TrackHistory.FirstOrDefault(e => e.TripReference == tripreference);
        }

        public async Task<List<TrackHistoryListViewModel>> GetTrackHistoryWithStatusAsync()
        {
            //var all = await _dbContext.TrackHistory
            //    .Include(s => s.Trips)
            //    .ThenInclude(x => x.Manifest)
            //    .ThenInclude(y => y.GroupWayBill)
            //    .ThenInclude(r => r.Shipment)
            //    .ToListAsync();

            var tracks =  _dbContext.IrisTrackView.OrderBy(d => d.CreatedBy).ToList(); 

            //var tracks = _dbContext.TrackHistory.OrderBy(x => x.CreatedDate).ToList();
            List<TrackHistoryListViewModel> allTracks = new List<TrackHistoryListViewModel>();

            foreach (var track in tracks)
            {
                var singleGroupVm = new TrackHistoryListViewModel();
                singleGroupVm.Id = track.Id;
                singleGroupVm.TripReference = track.TripReference;
                singleGroupVm.Action = track.Action.GetEnumDescription();
                singleGroupVm.Status = track.Status.GetEnumDescription();
                singleGroupVm.Location = track.Location;
                singleGroupVm.CreateDate = track.CreatedDate;
                singleGroupVm.Waybill = track.Waybill;
                singleGroupVm.ManifestCode = track.ManifestCode;
                //singleGroupVm.UserId = trip.UserId;
                //var user = await _userManager.FindByIdAsync(trip.Driver.ToString());
                //var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                allTracks.Add(singleGroupVm);
            }
            return allTracks;
        }

        public async Task<List<TrackHistoryListViewModel>> GetUserTrackHistoryWithStatusAsync(string userId)
        {

            var shipments = _dbContext.Shipment.Where(u => u.Customer == new Guid(userId)).OrderBy(d => d.CreatedBy).Select(x => x.Waybill).ToArray();
            var tracks = _dbContext.IrisTrackView.Where(x => shipments.Contains(x.Waybill)).OrderBy(d => d.CreatedBy).ToList();

            //var tracks = _dbContext.TrackHistory.OrderBy(x => x.CreatedDate).ToList();
            List<TrackHistoryListViewModel> allTracks = new List<TrackHistoryListViewModel>();

            foreach (var track in tracks)
            {
                var singleGroupVm = new TrackHistoryListViewModel();
                singleGroupVm.Id = track.Id;
                singleGroupVm.TripReference = track.TripReference;
                singleGroupVm.Action = track.Action.GetEnumDescription();
                singleGroupVm.Status = track.Status.GetEnumDescription();
                singleGroupVm.Location = track.Location;
                singleGroupVm.CreateDate = track.CreatedDate;
                singleGroupVm.Waybill = track.Waybill;
                singleGroupVm.ManifestCode = track.ManifestCode;
                //singleGroupVm.UserId = trip.UserId;
                //var user = await _userManager.FindByIdAsync(trip.Driver.ToString());
                //var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                allTracks.Add(singleGroupVm);
            }
            return allTracks;
        }


        public async Task<List<TrackHistoryListViewModel>> GetTrackHistoryWithStatusAsyncSearch(string code) 
        {
            var tracks = _dbContext.IrisTrackView.Where(s => (s.Waybill == code) || (s.ManifestCode == code) || (s.TripReference == code)).OrderBy(d => d.CreatedBy).ToList();

            //var tracks = _dbContext.TrackHistory.OrderBy(x => x.CreatedDate).ToList();
            List<TrackHistoryListViewModel> allTracks = new List<TrackHistoryListViewModel>();

            foreach (var track in tracks)
            {
                var singleGroupVm = new TrackHistoryListViewModel();
                singleGroupVm.Id = track.Id;
                singleGroupVm.TripReference = track.TripReference;
                singleGroupVm.Action = track.Action.GetEnumDescription();
                singleGroupVm.Status = track.Status.GetEnumDescription();
                singleGroupVm.Location = track.Location;
                singleGroupVm.CreateDate = track.CreatedDate;
                singleGroupVm.Waybill = track.Waybill;
                singleGroupVm.ManifestCode = track.ManifestCode;
                //singleGroupVm.UserId = trip.UserId;
                //var user = await _userManager.FindByIdAsync(trip.Driver.ToString());
                //var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                allTracks.Add(singleGroupVm);
            }
            return allTracks;
        }

        public async Task<List<TrackHistoryListViewModel>> GetUserTrackHistoryWithStatusAsyncSearch(string code, string userId)
        {
            var shipments = _dbContext.Shipment.Where(u => u.Customer == new Guid(userId)).OrderBy(d => d.CreatedBy).Select(x => x.Waybill).ToArray();
            var tracks = _dbContext.IrisTrackView.Where(s => shipments.Contains(s.Waybill) && (s.Waybill == code) || (s.ManifestCode == code) || (s.TripReference == code)).OrderBy(d => d.CreatedBy).ToList();

            //var tracks = _dbContext.TrackHistory.OrderBy(x => x.CreatedDate).ToList();
            List<TrackHistoryListViewModel> allTracks = new List<TrackHistoryListViewModel>();

            foreach (var track in tracks)
            {
                var singleGroupVm = new TrackHistoryListViewModel();
                singleGroupVm.Id = track.Id;
                singleGroupVm.TripReference = track.TripReference;
                singleGroupVm.Action = track.Action.GetEnumDescription();
                singleGroupVm.Status = track.Status.GetEnumDescription();
                singleGroupVm.Location = track.Location;
                singleGroupVm.CreateDate = track.CreatedDate;
                singleGroupVm.Waybill = track.Waybill;
                singleGroupVm.ManifestCode = track.ManifestCode;
                //singleGroupVm.UserId = trip.UserId;
                //var user = await _userManager.FindByIdAsync(trip.Driver.ToString());
                //var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                allTracks.Add(singleGroupVm);
            }
            return allTracks;
        }
    }
}