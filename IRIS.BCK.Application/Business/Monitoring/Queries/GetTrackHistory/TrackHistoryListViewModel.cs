using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistory
{
    public class TrackHistoryListViewModel
    {
        public Guid Id { get; set; }
        public string TripReference { get; set; }
        public string Action { get; set; }
        public string Location { get; set; }
        public string ActionTimeStamp { get; set; }
        public string Waybill { get; set; }
        public string ManifestCode { get; set; } 
        public string Status { get; set; }
        public DateTime CreateDate { get; set; } 
    }
}