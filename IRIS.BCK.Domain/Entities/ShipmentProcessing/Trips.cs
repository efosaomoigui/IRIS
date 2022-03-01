using IRIS.BCK.Core.Domain.Entities.FleetEntities;
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
        public int TripReference { get; set; }
        public string RouteCode { get; set; }
        public virtual List<Fleet> Fleet { get; set; }
        public int ManifestId { get; set; }
        public virtual List<Manifest> manifest { get; set; }
        public Guid Driver { get; set; }
        public Guid Dispatcher { get; set; }
        public decimal DriverDispatchFee { get; set; }
        public decimal Miscelleneous { get; set; }
        public decimal FuelCosts { get; set; }
        public decimal FuelUsed { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public StatusEnum Status { get; set; }
        //Enroute| AtDestination | BreakDown
    }
}