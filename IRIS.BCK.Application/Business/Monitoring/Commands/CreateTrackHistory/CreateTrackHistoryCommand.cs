﻿using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
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
        public string TripReference { get; set; }
        public ActionType Action { get; set; }
        public string Location { get; set; }
        public string ActionTimeStamp { get; set; }
        public TrackingStatus Status { get; set; }
    }
}