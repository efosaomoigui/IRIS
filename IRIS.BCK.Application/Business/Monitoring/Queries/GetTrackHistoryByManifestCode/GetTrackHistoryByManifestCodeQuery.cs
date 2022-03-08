using IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistoryById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistoryByManifestCode
{
    public class GetTrackHistoryByManifestCodeQuery : IRequest<TrackHistoryViewModel>
    {
        public Guid ManifestCode { get; set; }

        public GetTrackHistoryByManifestCodeQuery(string manifestcode)
        {
            Guid TrackHistoryGuid = new Guid(manifestcode);
            // TripId = TrackHistoryGuid;
        }
    }
}