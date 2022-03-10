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
        public string TripReference { get; set; }

        public GetTrackHistoryByTripIdQuery(string tripreference)
        {
            string TrackHistory = new string(tripreference);
            TripReference = TrackHistory;
        }
    }
}