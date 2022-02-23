using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
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
        private readonly IGenericRepository<TrackHistory> _trackHistoryRepository;
        private readonly IMapper _mapper;

        public GetTrackHistoryQueryHandler(IGenericRepository<TrackHistory> trackHistoryRepository, IMapper mapper)
        {
            _trackHistoryRepository = trackHistoryRepository;
            _mapper = mapper;
        }

        public async Task<List<TrackHistoryListViewModel>> Handle(GetTrackHistoryQuery request, CancellationToken cancellationToken)
        {
            var allTrackHistory = (await _trackHistoryRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<TrackHistoryListViewModel>>(allTrackHistory);
        }
    }
}