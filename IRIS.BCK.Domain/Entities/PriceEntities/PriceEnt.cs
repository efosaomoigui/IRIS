using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.PriceEntities
{
    public class PriceEnt : Auditable
    {
        public Guid Id { get; set; }
        public PriceCategory Category { get; set; }
        public Guid RouteId { get; set; }
        public decimal UnitWeight { get; set; }
        public decimal PricePerUnit { get; set; }
        public ICollection<Route> Routes { get; set; }
    } 
}