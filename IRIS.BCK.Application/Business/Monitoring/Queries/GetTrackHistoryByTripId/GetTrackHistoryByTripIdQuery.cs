using IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistoryById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistoryByTripId
{
    public class GetTrackHistoryByTripIdQuery : IRequest<TrackHistoryViewModel>
    {
        public Guid TripId { get; set; }

        public GetTrackHistoryByTripIdQuery(string tripid)
        {
            //TripId = TrackHistoryGuid;
            Guid TrackHistoryGuid = new Guid(tripid);
            TripId = TrackHistoryGuid;
        }
    }
}