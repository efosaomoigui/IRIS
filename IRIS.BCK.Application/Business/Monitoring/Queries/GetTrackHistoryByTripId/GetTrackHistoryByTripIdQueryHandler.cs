using AutoMapper;
using IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistoryById;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IMonitoringRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistoryByTripId
{
    public class GetTrackHistoryByTripIdQueryHandler : IRequestHandler<GetTrackHistoryByTripIdQuery, TrackHistoryViewModel>
    {
        private readonly ITrackHistoryRepository _trackHistoryRepository;
        private readonly IMapper _mapper;

        public GetTrackHistoryByTripIdQueryHandler(ITrackHistoryRepository trackHistoryRepository, IMapper mapper)
        {
            _trackHistoryRepository = trackHistoryRepository;
            _mapper = mapper;
        }

        public async Task<TrackHistoryViewModel> Handle(GetTrackHistoryByTripIdQuery request, CancellationToken cancellationToken)
        {
            var tripreference = request.TripReference;
            var trip = await _trackHistoryRepository.GetTrackHistoryByTripReference(tripreference);

            return _mapper.Map<TrackHistoryViewModel>(trip);
        }

        //public async Task<TrackHistoryViewModel> Handle(GetTrackHistoryByIdQuery request, CancellationToken cancellationToken)
        //{
        //    var trackhistoryid = request.Id.ToString();
        //    var trackhistory = await _trackHistoryRepository.GetTrackHistoryById(trackhistoryid);

        //    return _mapper.Map<TrackHistoryViewModel>(trackhistory);
        //}
    }
}