using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetGroupWayBill;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using IRIS.BCK.Core.Domain.Entities.GroupWayBillManifestMapEntities;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetTrips
{
    public class TripListViewModel
    {
        public Guid Id { get; set; }
        public string TripReference { get; set; }
        public string ManifestCode { get; set; }
        public string RouteCode { get; set; }
        public string RouteName { get; set; } 
        public string Departure { get; set; }
        public string Destination { get; set; }
        public Guid UserId { get; set; }
        public string FleetChasis { get; set; } 
        public string FleetFullDetails { get; set; }  
        public Guid Driver { get; set; }
        public string DriverName { get; set; } 
        public string DriverPhone { get; set; }  
        public DateTime CreatedDate { get; set; }   
        public Guid Dispatcher { get; set; }
        public List<GroupWayBillListViewModel> groupwaybills { get; set; } 
    }
}