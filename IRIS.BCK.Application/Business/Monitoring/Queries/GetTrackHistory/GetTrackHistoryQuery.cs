using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistory
{
    public class GetTrackHistoryQuery : IRequest<List<TrackHistoryListViewModel>>
    {
    }

    public class GetUserTrackHistoryQuery : IRequest<List<TrackHistoryListViewModel>>
    {
        public string userId;
        public GetUserTrackHistoryQuery(string userId = null)
        {
            this.userId = userId;
        }
    }

    public class GetTrackHistorySearchQuery : IRequest<List<TrackHistoryListViewModel>> 
    {
        public GetTrackHistorySearchQuery(string grpcode)
        {
            Code = grpcode;
        }

        public string Code { get; set; }
    }

    public class GetUserTrackHistorySearchQuery : IRequest<List<TrackHistoryListViewModel>>
    {
        public GetUserTrackHistorySearchQuery(string grpcode, string userId = null)
        {
            Code = grpcode;
            UserId = userId;
        }

        public string UserId { get; set; } 
        public string Code { get; set; }
    }
}