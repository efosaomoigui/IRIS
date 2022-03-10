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

namespace IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistoryById
{
    public class GetTrackHistoryByIdQueryHandler : IRequestHandler<GetTrackHistoryByIdQuery, TrackHistoryViewModel>
    {
        private readonly ITrackHistoryRepository _trackHistoryRepository;
        private readonly IMapper _mapper;

        public GetTrackHistoryByIdQueryHandler(ITrackHistoryRepository trackHistoryRepository, IMapper mapper)
        {
            _trackHistoryRepository = trackHistoryRepository;
            _mapper = mapper;
        }

        public async Task<TrackHistoryViewModel> Handle(GetTrackHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            var trackhistoryid = request.Id.ToString();
            var trackhistory = await _trackHistoryRepository.GetTrackHistoryById(trackhistoryid);

            return _mapper.Map<TrackHistoryViewModel>(trackhistory);
        }
    }
}