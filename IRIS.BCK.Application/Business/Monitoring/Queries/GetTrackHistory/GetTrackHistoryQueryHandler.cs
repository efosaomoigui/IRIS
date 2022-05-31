using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IMonitoringRepositories;
using IRIS.BCK.Core.Domain.Entities.Monitoring;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistory
{
    public class GetTrackHistoryQueryHandler : IRequestHandler<GetTrackHistoryQuery, List<TrackHistoryListViewModel>>
    {
        private readonly ITrackHistoryRepository _trackHistoryRepository;
        private readonly IMapper _mapper;

        public GetTrackHistoryQueryHandler(IMapper mapper, ITrackHistoryRepository trackHistoryRepository = null)
        {
            _mapper = mapper;
            _trackHistoryRepository = trackHistoryRepository;
        }

        public async Task<List<TrackHistoryListViewModel>> Handle(GetTrackHistoryQuery request, CancellationToken cancellationToken)
        {
            var allTrackHistory = await _trackHistoryRepository.GetTrackHistoryWithStatusAsync();
            return allTrackHistory;
        }
    }

    public class GetUserTrackHistoryQueryHandler : IRequestHandler<GetUserTrackHistoryQuery, List<TrackHistoryListViewModel>>
    {
        private readonly ITrackHistoryRepository _trackHistoryRepository;
        private readonly IMapper _mapper;

        public GetUserTrackHistoryQueryHandler(IMapper mapper, ITrackHistoryRepository trackHistoryRepository = null)
        {
            _mapper = mapper;
            _trackHistoryRepository = trackHistoryRepository;
        }

        public async Task<List<TrackHistoryListViewModel>> Handle(GetUserTrackHistoryQuery request, CancellationToken cancellationToken)
        {
            var allTrackHistory = await _trackHistoryRepository.GetUserTrackHistoryWithStatusAsync(request.userId); 
            return allTrackHistory;
        }
    }

    public class GetTrackHistorySearchQueryHandler : IRequestHandler<GetTrackHistorySearchQuery, List<TrackHistoryListViewModel>>
    {
        private readonly ITrackHistoryRepository _trackHistoryRepository;
        private readonly IMapper _mapper;

        public GetTrackHistorySearchQueryHandler(IMapper mapper, ITrackHistoryRepository trackHistoryRepository = null)
        {
            _mapper = mapper;
            _trackHistoryRepository = trackHistoryRepository;
        }

        public async Task<List<TrackHistoryListViewModel>> Handle(GetTrackHistorySearchQuery request, CancellationToken cancellationToken)
        {
            var allTrackHistory = await _trackHistoryRepository.GetTrackHistoryWithStatusAsyncSearch(request.Code);
            return allTrackHistory;
        }
    }


    public class GetUserTrackHistorySearchQueryHandler : IRequestHandler<GetUserTrackHistorySearchQuery, List<TrackHistoryListViewModel>> 
    {
        private readonly ITrackHistoryRepository _trackHistoryRepository;
        private readonly IMapper _mapper;

        public GetUserTrackHistorySearchQueryHandler(IMapper mapper, ITrackHistoryRepository trackHistoryRepository = null) 
        {
            _mapper = mapper;
            _trackHistoryRepository = trackHistoryRepository;
        }

        public async Task<List<TrackHistoryListViewModel>> Handle(GetUserTrackHistorySearchQuery request, CancellationToken cancellationToken)
        {
            var allTrackHistory = await _trackHistoryRepository.GetUserTrackHistoryWithStatusAsyncSearch(request.Code, request.UserId); 
            return allTrackHistory;
        }
    }
}