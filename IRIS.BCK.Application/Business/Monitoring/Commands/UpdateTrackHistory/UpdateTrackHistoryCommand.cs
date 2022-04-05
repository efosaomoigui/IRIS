using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Commands.UpdateTrackHistory
{
    public class UpdateTrackHistoryCommand : IRequest<UpdateTrackHistoryCommandResponse>
    {
        public Guid Id { get; set; }
        public string TripReference { get; set; }
        public string Action { get; set; }
        public string Location { get; set; }
        public string ActionTimeStamp { get; set; }
        public string Status { get; set; }
    }
}