using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using IRIS.BCK.Core.Domain.Entities.GroupWayBillManifestMapEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.ShipmentProcessing
{
    public class Trips : Auditable
    {
        public Guid Id { get; set; }
        public string TripReference { get; set; }
        public string RouteCode { get; set; }
        public Guid RouteFleetId { get; set; }  
        public Fleet Fleet { get; set; }
        public Guid Driver { get; set; }
        public Guid Dispatcher { get; set; }
        public string ManifestCode { get; set; } 
        public Manifest Manifest { get; set; } 
        public Guid ManifestId { get; set; }  
    }
}