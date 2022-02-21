using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Commands.CreateTrackHistory
{
    public class CreateTrackHistoryCommand : IRequest<CreateTrackHistoryCommandResponse>
    {
        public Guid Id { get; set; }
        public int TripId { get; set; }
        public Trips Trip { get; set; }
        public string Action { get; set; }
        public Location Location { get; set; }
        public ActionTimeStamp TimeStamp { get; set; }
        public string Status { get; set; }
    }
}