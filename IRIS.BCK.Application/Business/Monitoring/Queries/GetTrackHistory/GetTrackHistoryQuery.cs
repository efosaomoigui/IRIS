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
    
    public class GetTrackHistorySearchQuery : IRequest<List<TrackHistoryListViewModel>> 
    {
        public GetTrackHistorySearchQuery(string grpcode)
        {
            Code = grpcode;
        }

        public string Code { get; set; }
    }
}