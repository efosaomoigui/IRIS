using IRIS.BCK.Core.Application.Business.Monitoring.Commands.CreateTrackHistory;
using IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateTrips;
using IRIS.BCK.Core.Domain.Entities.Monitoring;
using IRIS.BCK.Core.Domain.EntityEnums;
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
                TripReference = request.TripReference,
                Action = request.Action,
                ActionTimeStamp = request.ActionTimeStamp,
                Status = request.Status,
                Location = request.Location,

            };
        }

        public static TrackHistory CreateTrackHistoryMapsCommandInit(PaymentCriteriaCommand request) 
        {
            return new TrackHistory
            {
                TripReference = "0000010000",
                Action = ActionType.Start,
                ActionTimeStamp = "",
                Status = TrackingStatus.Shipment_Registered_and_Moved_to_Processing,
                Location = "warehouse",
            };
        }
        public static TrackHistory CreateTrackHistoryMapsCommandTripReg(CreateTripCommand request) 
        {
            return new TrackHistory
            {
                TripReference = "0000100000",
                Action = ActionType.Start,
                ActionTimeStamp = "",
                Status = TrackingStatus.Shipment_Registered_For_Dispatch,
                Location = "warehouse",
            };
        }
    }
}