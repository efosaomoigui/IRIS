using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.Monitoring
{
    public class TrackHistory : Auditable
    {
        public Guid Id { get; set; }
        public string TripReference { get; set; }
        public ActionType Action { get; set; }
        public string Location { get; set; }
        public string ActionTimeStamp { get; set; }
        public TrackingStatus Status { get; set; }
        public Trips Trips { get; set; }       
        public Guid TripsId { get; set; }       
    }

    //[Id]
    //  ,[Action]
    //  ,[LastModifiedBy]
    //  ,[LastModifiedDate]
    //  ,[TripReference]
    //  ,[st]
    //  ,[CreatedBy]
    //  ,[ActionTimeStamp]
    //  ,[Location]
    //  ,[Waybill]
    //  ,[Status]
    //  ,[CreatedDate]
    //  ,[ManifestCode
    //  ,[GroupCode] 

    public class IrisTrackView : Auditable 
    {
        public Guid Id { get; set; }
        public string TripReference { get; set; }
        public ActionType Action { get; set; }
        public string Location { get; set; }
        public string Waybill { get; set; }
        public string ActionTimeStamp { get; set; }
        public string ManifestCode { get; set; }
        public TrackingStatus St { get; set; }
        public TrackingStatus Status { get; set; }  
    } 
}