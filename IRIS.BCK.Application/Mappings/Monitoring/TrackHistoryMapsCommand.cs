using IRIS.BCK.Core.Application.Business.Monitoring.Commands.CreateTrackHistory;
using IRIS.BCK.Core.Domain.Entities.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.Monitoring
{
    public static class TrackHistoryMapsCommand
    {
        public static TrackHistory CreateTrackHistoryMapsCommand(CreateTrackHistoryCommand request)
        {
            return new TrackHistory
            {
                Trip = request.Trip,
                TimeStamp = request.TimeStamp,
                Status = request.Status,
                Location = request.Location,
                TripId = request.TripId
            };
        }
    }
}