using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistoryById
{
    public class GetTrackHistoryByIdQuery : IRequest<TrackHistoryViewModel>
    {
        public Guid Id { get; set; }

        public GetTrackHistoryByIdQuery(string trackhistoryid)
        {
            //TripId = TrackHistoryGuid;
            Guid TrackHistoryGuid = new Guid(trackhistoryid);
            Id = TrackHistoryGuid;
        }
    }
}